using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    int damage;
    Transform startingLoc, target;
    LineRenderer laser;
	// Use this for initialization
	void Start () {
        laser = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        laser.SetPosition(0, startingLoc.position);
        laser.SetPosition(1, target.position);
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



}
