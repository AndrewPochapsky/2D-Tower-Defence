using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private int damage;
    private float speed;
    private Transform enemyTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyTarget != null)
        {
            LookAtTarget(enemyTarget);
            MoveTowardsTarget(enemyTarget);
        }
        else
        {
            Destroy(gameObject);
        }
        

	}

    public void SetTarget(Transform target)
    {
        enemyTarget = target;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public int GetDamage()
    {
        return damage;
    }

    private void LookAtTarget(Transform target)
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void MoveTowardsTarget(Transform target)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    

}
