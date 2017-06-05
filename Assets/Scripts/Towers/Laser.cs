using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    int damage;
    float time = 2;
    Transform startingLoc, target;
    LineRenderer laser;
    bool dealingDamage = false;
	// Use this for initialization
	void Start () {
        laser = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        laser.SetPosition(0, startingLoc.position);
        laser.SetPosition(1, target.position);
        print("Time: " + time);
        if (!dealingDamage)
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
