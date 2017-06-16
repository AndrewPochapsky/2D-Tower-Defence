using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Laser : MonoBehaviour {

    int damage;
    
    Transform startingLoc, target;
    LineRenderer laser;
    bool dealingDamage = false;
	// Use this for initialization
	void Start () {
        laser = GetComponent<LineRenderer>();
       
	}

    // Update is called once per frame
    void Update() {
        if (target == null || target.GetComponent<Enemy>().Dead)
        {
            gameObject.SetActive(false);
            dealingDamage = false;
            //print("target is null");
        }
       
        laser.SetPosition(0, startingLoc.position);
        if (target != null && !target.GetComponent<Enemy>().Dead)
        {
            laser.SetPosition(1, target.position);
            print("settting laser position");
        }
        if(gameObject.activeInHierarchy && !dealingDamage)
        {
            print("fak");
        }    
        
        if (target!=null && !dealingDamage)
        {
            StartCoroutine(DealDamage());
        }
       
     
        
	}

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void SetStart(Transform start)
    {
        startingLoc = start;
    }
    public Transform GetTarget()
    {
        return target;
    }
    public void SetTarget(Transform end)
    {
        target = end;
    }
    public void SetDealingDamage(bool value)
    {
        dealingDamage = value;
    }

    private IEnumerator DealDamage()
    {
        dealingDamage = true;
        Enemy enemy = target.gameObject.GetComponent<Enemy>();
        enemy.DealDamage(damage);
        if(!enemy.laserTowers.Contains(transform.parent))
            enemy.laserTowers.Add(transform.parent);
        yield return new WaitForSeconds(1);
        StartCoroutine(DealDamage());

    }

    private bool CanTarget()
    {
        return !target.gameObject.GetComponent<Enemy>().laserTowers.Contains(transform.parent);
    }



}
