using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //TODO add an enumerator for types of resistances
    //Example: Some enemies resistant to arrows but weak to fire
    protected string Name { get; set; }
    protected int MaxHealth { get; set; }
    protected int CurrentHealth { get; set; }
    protected int Damage { get; set; }
    protected float Speed { get; set; }

    private Transform nextWaypoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CurrentHealth <= 0)
        {
            Die();
        }
	}

    public string GetName()
    {
        return Name;
    }

    protected void SetUpStats(string name, int maxHealth, int damage, float speed)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        Damage = damage;
        Speed = speed;
    }

    protected virtual void Move()
    {

    }

    protected void Die()
    {
        //play sound, give currency/exp to player
        Destroy(gameObject);
    }







}
