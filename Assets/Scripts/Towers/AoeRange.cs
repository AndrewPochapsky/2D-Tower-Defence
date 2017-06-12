using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AoeRange : MonoBehaviour {
    
    private int damage;
    private float fireRate;
    List<Enemy> enemies;
    EffectManager effectManager;
	// Use this for initialization
	void Start () {
        enemies = new List<Enemy>();
        effectManager = GameObject.FindObjectOfType<EffectManager>();
	}
	
	// Update is called once per frame
	void Update () {
        SlowEnemies();
	}

    public void SetDamage(int value)
    {
        damage = value;
    }
    public void SetFireRate(int value)
    {
        fireRate = value;
    }

    public void SlowEnemies()
    {
        //slow enemies in cone, display particle effect
        foreach(Enemy enemy in enemies)
        {
            //effectManager.ApplyEffect(enemy, EffectManager.EffectType.SLOW);
            if (!enemy.IsSlowed())
            {
                enemy.AlterSpeed(enemy.GetSpeed()/-2);
                enemy.SetSlowed(true);
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            if (!enemies.Contains(collision.GetComponent<Enemy>()))
            {
                enemies.Add(collision.GetComponent<Enemy>());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            if (enemies.Contains(collision.GetComponent<Enemy>()))
            {
                
                enemies.Remove(collision.GetComponent<Enemy>());
                collision.GetComponent<Enemy>().AlterSpeed(collision.GetComponent<Enemy>().GetSpeed());
                collision.GetComponent<Enemy>().SetSlowed(false);
            }
        }
    }



}
