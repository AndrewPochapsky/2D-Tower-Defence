using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TowerRange : MonoBehaviour {
    private Enemy[] detectedEnemies;
    private int numOfTargets;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Enemy[] GetEnemies()
    {
        return detectedEnemies;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.GetComponent<Enemy>())
        {
            for(int i = 0; i < detectedEnemies.Length; i++)
            {
                if(detectedEnemies[i] == null)
                {
                    detectedEnemies[i] = collision.GetComponent<Enemy>();
                    break;
                }
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.GetComponent<Enemy>())
        {
            int index = Array.IndexOf(detectedEnemies, collision.GetComponent<Enemy>());
            detectedEnemies[index] = null;
            print("enemy getting set to null");
        }
    }

    public void SetNumOfTargets(int value)
    {
        numOfTargets = value;
        print("setting numOfTargets to " + value);
        detectedEnemies = new Enemy[numOfTargets];
        for (int i = 0; i < detectedEnemies.Length; i++)
        {
            detectedEnemies[i] = null;
        }
    }
}
