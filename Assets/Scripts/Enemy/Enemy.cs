using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    

    //TODO add an enumerator for types of resistances
    //Example: Some enemies resistant to arrows but weak to fire
    protected string Name { get; set; }
    protected int MaxHealth { get; set; }
    protected int CurrentHealth { get; set; }
    protected int Damage { get; set; }
    protected float Speed { get; set; }

    public bool Targeted
    {
        get
        {
            return targeted;
        }

        set
        {
            targeted = value;
        }
    }

    private bool targeted = false;
    private bool isSlowed = false;
    private Rigidbody2D rb;
    private List<Transform> waypoints;
    private Transform waypointsTransform;
    private Transform nextWaypoint;
    private float tolerance = 0.1f;
    private StatusIndicator statusIndicator;
    public List<Transform> laserTowers;


	// Use this for initialization
	protected virtual void Start () {
        laserTowers = new List<Transform>();
        statusIndicator = GetComponent<StatusIndicator>();
        waypointsTransform = GameObject.FindGameObjectWithTag("Waypoints").transform;
        rb = GetComponent<Rigidbody2D>();
        waypoints = new List<Transform>();
        for(int i =0; i < waypointsTransform.childCount; i++)
        {
            waypoints.Add(waypointsTransform.GetChild(i));
        }
        nextWaypoint = waypoints[0];
     
       
	}
    
	
	// Update is called once per frame
	protected virtual void Update () {
        Move();
        if (CurrentHealth <= 0)
        {
            Die();
        }
        print("num of towers targeting: " + laserTowers.Count);

	}
   
    public string GetName()
    {
        return Name;
    }
    public int GetDamage()
    {
        return Damage;
    }
    public string GetHealthString()
    {
        return CurrentHealth + "/" + MaxHealth;
    }
    public int GetCurrentHealth()
    {
        return CurrentHealth;
    }
    public int GetMaxHealth()
    {
        return MaxHealth;
    }
    public float GetSpeed()
    {
        return Speed;
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
                waypoints.RemoveAt(0);

                nextWaypoint = waypoints[0];
            }
                
        }
       
    }

    protected void Die()
    {
        //play sound, give currency/exp to player
        Destroy(gameObject);
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
        if (collision.GetComponent<DamageSpread>())
        {
            DamageSpread spread = collision.GetComponent<DamageSpread>();
            CurrentHealth -= spread.GetDamage();
            statusIndicator.SetHealth();
        }

        if (collision.GetComponent<Projectile>())
        {
            Projectile proj = collision.GetComponent<Projectile>();
            CurrentHealth -= proj.GetDamage();
            //print("taking damage");
            statusIndicator.SetHealth();
            Destroy(collision.gameObject);
           
        }
      

        
    }

    public void DealDamage(int damage)
    {

        targeted = true;
        CurrentHealth -= damage;
        statusIndicator.SetHealth();
    }

    public void AlterSpeed(float value)
    {
        Speed += value;
    }

    public bool IsSlowed()
    {
        return isSlowed;
    }
    public void SetSlowed(bool value)
    {
        isSlowed = value;
    }


}
