﻿using System.Collections;
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
    //TODO make on ontriggerstay thing for towers other than laser
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(transform.parent.GetComponent<LaserTower>()&&collision.GetComponent<Enemy>())
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!transform.parent.GetComponent<LaserTower>() && collision.GetComponent<Enemy>())
        {
            for (int i = 0; i < detectedEnemies.Length; i++)
            {
                if (detectedEnemies[i] == null)
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
            print("index: " + index);
            collision.GetComponent<Enemy>().SetTargetedByLaser(false);
            detectedEnemies[index] = null;
            //need to find  way to update the laser's final transform
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

    public void IncreaseRange(float range)
    {
        transform.localScale += new Vector3(range, range, 0);
    }


}
