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

    private Rigidbody2D rb;
    private List<Transform> waypoints;
    private Transform nextWaypoint;
    private float tolerance = 0.1f;

	// Use this for initialization
	protected virtual void Start () {

        
        rb = GetComponent<Rigidbody2D>();
        waypoints = new List<Transform>();
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(obj.transform.transform);
        }
        nextWaypoint = waypoints[waypoints.Count-1];
       
	}
    
	
	// Update is called once per frame
	protected virtual void Update () {
        Move();
        if (CurrentHealth <= 0)
        {
            Die();
        }
	}
   
    public string GetName()
    {
        return Name;
    }
    public int GetDamage()
    {
        return Damage;
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
       
        transform.position = Vector2.MoveTowards(transform.position, nextWaypoint.position, Speed*Time.deltaTime);
        if (CheckIfReachedWaypoint())
        {

            if (waypoints.Count - 1 > 0)
            {
                waypoints.RemoveAt(waypoints.Count - 1);

                nextWaypoint = waypoints[waypoints.Count - 1];
            }
                
        }
        print("moving");
    }

    protected void Die()
    {
        //play sound, give currency/exp to player
        Destroy(gameObject);
    }

    private Vector2 ChooseDirection()
    {
        float xDifference = Mathf.Abs(nextWaypoint.position.x - transform.position.x);
        float yDifference = Mathf.Abs(nextWaypoint.position.y - transform.position.y);

        if(nextWaypoint.position.x > transform.position.x && xDifference >=0.25f)
        {
            return Vector2.right;
        }
        return Vector2.up;
    }

    private bool CheckIfReachedWaypoint()
    {
        float xDifference = Mathf.Abs(transform.position.x - nextWaypoint.position.x);
        float yDifference = Mathf.Abs(transform.position.y - nextWaypoint.position.y);

        if(xDifference<=tolerance && yDifference <= tolerance)
        {
            return true;
        }
        return false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision on enemy: " + collision.name);
        if (collision.GetComponent<Projectile>())
        {
            Projectile proj = collision.GetComponent<Projectile>();
            CurrentHealth -= proj.GetDamage();
            print("CUrrent health: " + CurrentHealth);
            Destroy(collision.gameObject);
        }
    }
   




}
