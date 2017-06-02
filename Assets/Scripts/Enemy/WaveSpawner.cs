using System.Collections;
using System.Collections.Generic;

using UnityEngine;




[System.Serializable]
public class Wave
{
    public Enemy enemy1, enemy2, enemy3, enemy4;
    public float spawnTimer;
    public int numOfEnemiesToSpawn;
    [HideInInspector]
    public bool initialized= false;
    

}

public class WaveSpawner : MonoBehaviour {
    enum SpawnState { WAITING, COUNTING, SPAWNING };
    SpawnState spawnState;

    public Wave[] waves;
    private int waveNum= 1;
    private Enemy[] enemies;
    private int numOfEnemies = 4;
    public Transform spawnPoint;
    float searchCountDown = 1f;
    float waveCountDown = 3f;
    // Use this for initialization
    void Start () {
        spawnState = SpawnState.COUNTING;
	}
	
	// Update is called once per frame
	void Update () {
        print("SPAWNSTATE: " + spawnState);
        if (spawnState == SpawnState.WAITING)
        {
            if (!EnemyAlive())
            {
                print("wave completed");
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if(waveCountDown <= 0)
        {
            if (spawnState != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave());
            }
        }
        else
        {

            waveCountDown -= Time.deltaTime;
        }
       
       
	}

    private IEnumerator SpawnWave()
    {
        spawnState = SpawnState.SPAWNING;
        print("SpawnWave: " + waveNum);
        //spawnState = SpawnState.SPAWNING;
        Wave currentWave = waves[waveNum-1];
        //TODO: There must be a better way to do this
        if (!currentWave.initialized)
        {
            enemies = new Enemy[numOfEnemies];
            enemies[0] = currentWave.enemy1;
            enemies[1] = currentWave.enemy2;
            enemies[2] = currentWave.enemy3;
            enemies[3] = currentWave.enemy4;
            currentWave.initialized = true;
        }

        foreach(Enemy enemy in enemies)
        {
            
            if (enemy != null)
            {
                for(int i = 0; i< currentWave.numOfEnemiesToSpawn; i++)
                {
                    print("Spawning Enemy: " + enemy.name);
                    Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
                    yield return new WaitForSeconds(currentWave.spawnTimer);
                }
               
            }
        }
        spawnState = SpawnState.WAITING;



    }
    private void WaveCompleted()
    {
        waveNum++;
        waveCountDown = 3f;
        spawnState = SpawnState.COUNTING;
    }
    

    private bool EnemyAlive()
    {

        searchCountDown -= Time.deltaTime;
        if(searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindObjectsOfType<Enemy>().Length == 0)
            {
                return false;
            }
        }

        return true;
    }

}


