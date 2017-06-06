using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : Tower {

    GameObject proj;
    Laser laser;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetStats(TowerType.Type.LASER, "Laser Tower", 7, 0, 0, 8, 600, 1, 150, 1);
        proj = Instantiate(Resources.Load("Projectiles/" + Type), transform.position, transform.rotation) as GameObject;
        proj.SetActive(false);
        laser = proj.GetComponent<Laser>();
        laser.SetDamage(2);
        laser.SetStart(cannon);
    }

    protected override void Update()
    {
        targets = range.GetEnemies();
        
    }
    private void LateUpdate()
    {
        if (targets[0] != null)
        {
            print("firing in late update");
            Fire();
        }
        else
        {
            laser.gameObject.SetActive(false);
            laser.SetDealingDamage(false);
        }
    }


    protected override void Fire()
    {
        //fire laser at it, deal damage overtime
        laser.gameObject.SetActive(true);
        laser.SetTarget(targets[0].transform);

       
    }
}
