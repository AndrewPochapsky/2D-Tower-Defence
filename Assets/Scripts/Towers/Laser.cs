using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (target == null)
        {
            gameObject.SetActive(false);

        }
        else
        {
            print("target is not null");
        }
        laser.SetPosition(0, startingLoc.position);
        if(target!=null)
            laser.SetPosition(1, target.position);
        
        if (target!=null && !dealingDamage)
        {
            StartCoroutine(DealDamage());
        }
        //print("Target: " + target.name);
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
        target.gameObject.GetComponent<Enemy>().DealDamage(damage);
        yield return new WaitForSeconds(1);
        StartCoroutine(DealDamage());

    }


}
