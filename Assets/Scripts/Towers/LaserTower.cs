using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LaserTower : Tower {

    public static int buildCost = 600;

    GameObject proj;
    Laser[] laser;
    int tempCount = 0;

    private void Awake()
    {
        SetStats(TowerType.Type.LASER, "Laser Tower", 7, 0, 0, 8, buildCost, 1, 150, 3);
    }

    // Use this for initialization
    protected override void Start () {
        
      
        base.Start();
        print("num of targets :" + NumOfTargets);
        laser = new Laser[NumOfTargets];
        for(int i = 0; i < NumOfTargets; i++)
        {
            proj = Instantiate(Resources.Load("Projectiles/" + Type), transform.position, transform.rotation) as GameObject;
            print("projectile: " + proj.name);
            laser[i] = proj.GetComponent<Laser>();
            laser[i].SetDamage(2);
            laser[i].SetStart(cannon);
            proj.SetActive(false);
        }
       
        
    }

    protected override void Update()
    {
        targets = range.GetEnemies();
        CheckIfEnemyOutOfRange();
        
    }
    private void LateUpdate()
    {
        Fire();
       
    }

    public override void Upgrade()
    {
        base.Upgrade();
        Damage += 1;
        UpgradeCost += 300;
        range.IncreaseRange(0.5f);
    }

    protected override void Fire()
    {
        //fire laser at it, deal damage overtime

        for(int i = 0; i< laser.Length; i++)
        {
            if (laser[i].GetTarget() == null && GetTargetableEnemy()!=null)
            {
                laser[i].gameObject.SetActive(true);
                Enemy enemy = GetTargetableEnemy();
                if (enemy != null)
                {
                    enemy.SetTargetedByLaser(true);
                    laser[i].SetTarget(enemy.transform);
                }
               
            }
        }

       

       
    }
    private Enemy GetTargetableEnemy()
    {

        for (int i = 0; i < NumOfTargets; i++)
        {
            if (targets[i] != null)
            {
                if (!targets[i].IsTargetedByLaser())
                {
                    return targets[i];
                }
            }

        }

        return null;
    }


    private void CheckIfEnemyOutOfRange()
    {
        foreach(Laser _laser in laser)
        {
            if (_laser.GetTarget()!=null && !targets.Contains(_laser.GetTarget().GetComponent<Enemy>()))
            {
                _laser.SetTarget(null);
                _laser.SetDealingDamage(false);
            }
        }
        
    }


}
