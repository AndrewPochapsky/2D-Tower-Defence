using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour {
    private Enemy detectedEnemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Enemy GetEnemy()
    {
        return detectedEnemy;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Collision Range: " + collision.name);
        if (collision.GetComponent<Enemy>())
        {
            detectedEnemy = collision.GetComponent<Enemy>();
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            detectedEnemy = null;
        }
    }
}
