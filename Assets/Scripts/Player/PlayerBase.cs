using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

    GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.GetComponent<Enemy>())
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            gm.SetCurrentHealth(gm.GetCurrentHealth() - enemy.GetDamage());
            print(enemy.GetDamage()+ " damage dealt to base, Health: "+gm.GetCurrentHealth() +"/"+gm.GetMaxHealth());

            Destroy(enemy.gameObject);
        }

    }
}
