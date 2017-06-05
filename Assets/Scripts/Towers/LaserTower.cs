using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : Tower {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetStats(TowerType.Type.LASER, "Laser Tower", 7, 0, 0, 8, 600, 1, 150);
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}

    protected override void Fire()
    {
        if (target != null)
        {
            //fire laser at it, deal damage overtime
        }
    }
}
