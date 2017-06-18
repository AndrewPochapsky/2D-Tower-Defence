using System.Collections;
using System.Collections.Generic;

using UnityEngine;




[System.Serializable]
public class Wave
{
    public GameObject enemy1, enemy2, enemy3, enemy4;
    public float spawnTimer;
    public int numOfEnemy1, numOfEnemy2, numOfEnemy3, numOfEnemy4;
    [HideInInspector]
    public bool initialized= false;
    

}

public class WaveSpawner : MonoBehaviour {
    public enum SpawnState { WAITING, COUNTING, SPAWNING , PREPARING};
    public static SpawnState spawnState;

    public Wave[] waves;
    private static int waveNum= 1;
    private static int totalWaves;
    private GameObject[] enemies;
    private int[] amounts;
    private int numOfEnemies = 4;
    public Transform spawnPoint;
    float searchCountDown = 1f;
    float waveCountDown = 3f;
    private GameManager gm;
    private UIController uiController;
    private LevelManager levelManager;
    // Use this for initialization
    void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        uiController = GameObject.FindObjectOfType<UIController>();
        spawnState = SpawnState.PREPARING;
        totalWaves = waves.Length;
	}
	
	// Update is called once per frame
	void Update () {
        if (spawnState != SpawnState.PREPARING)
        {
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
            if (waveCountDown <= 0)
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
       
       
       
	}

    private IEnumerator SpawnWave()
    {
        spawnState = SpawnState.SPAWNING;

        //spawnState = SpawnState.SPAWNING;
        Wave currentWave = waves[waveNum-1];
        //TODO: There must be a better way to do this
        if (!currentWave.initialized)
        {
            enemies = new GameObject[numOfEnemies];
            amounts = new int[numOfEnemies];
            enemies[0] = currentWave.enemy1;
            enemies[1] = currentWave.enemy2;
            enemies[2] = currentWave.enemy3;
            enemies[3] = currentWave.enemy4;

            amounts[0] = currentWave.numOfEnemy1;
            amounts[1] = currentWave.numOfEnemy2;
            amounts[2] = currentWave.numOfEnemy3;
            amounts[3] = currentWave.numOfEnemy4;

            currentWave.initialized = true;
            
        }


        for(int i = 0; i<enemies.Length; i++)
        {
            
            if (enemies[i] != null)
            {
                for(int x = 0; x < amounts[i]; x++)
                {
                    
                    Instantiate(enemies[i], spawnPoint.position, spawnPoint.rotation);
                    yield return new WaitForSeconds(currentWave.spawnTimer);
                }
               
            }
        }
        spawnState = SpawnState.WAITING;



    }
    private void WaveCompleted()
    {
        if (waveNum + 1 <= waves.Length)
        {
            waveNum++;
            gm.IncreaseCurrency(200);
            uiController.EnableStartButton();
            spawnState = SpawnState.PREPARING;
        }
        else
        {
            //end of game
            levelManager.LoadLevel("03EndWin");
            
        }
       
        waveCountDown = 3f;
        //spawnState = SpawnState.COUNTING;
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

    public static string GetWaveText()
    {
        return waveNum + "/" + totalWaves;
    }


}


