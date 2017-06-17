using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LaserTower : Tower {

    public static int buildCost = 750;
    //target not being reset i think]
    GameObject proj;
    Laser[] lasers;
    int tempCount = 0;
    Transform cannonTransform;
    private void Awake()
    {
        SetStats(Type.LASER, "Laser Tower", 7, 0, 0, 8, buildCost, 1, 150, 3);
    }

    // Use this for initialization
    protected override void Start () {


        //base.Start();
        range = transform.GetChild(0).GetComponent<TowerRange>();
        cannonTransform = transform.parent.GetChild(0);
        targets = new Enemy[NumOfTargets];
        range.SetNumOfTargets(NumOfTargets);

        lasers = new Laser[NumOfTargets];
        for(int i = 0; i < NumOfTargets; i++)
        {
            proj = Instantiate(Resources.Load("Projectiles/" + Type), transform.position, transform.rotation) as GameObject;

            lasers[i] = proj.GetComponent<Laser>();
            lasers[i].SetDamage(2);
            lasers[i].SetStart(cannonTransform);
            lasers[i].transform.SetParent(this.transform);
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

    public override void Remove()
    {
        foreach(Laser laser in lasers)
        {
            Destroy(laser.gameObject);
        }
        base.Remove();
    }

    protected void Fire()
    {
        //fire laser at it, deal damage overtime

        for(int i = 0; i< lasers.Length; i++)
        {
            if (lasers[i].GetTarget() == null && GetTargetableEnemy()!=null)
            {
                lasers[i].gameObject.SetActive(true);
                print("yes");
                Enemy enemy = GetTargetableEnemy();
                print(enemy);
                if (enemy != null && !enemy.laserTowers.Contains(transform))
                {
                    print("setting shit");
                    lasers[i].SetTarget(enemy.transform);
                   
                    lasers[i].GetTarget().GetComponent<Enemy>().laserTowers.Add(transform);
                    print("adding");
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
                if (!targets[i].laserTowers.Contains(transform))
                {
                    print("getting targetable enemy");
                    //targets[i].laserTowers.Add(transform);
                    return targets[i];
                }
            }

        }

        return null;
    }


    private void CheckIfEnemyOutOfRange()
    {
        foreach(Laser _laser in lasers)
        {
            if (_laser.GetTarget()!=null && !targets.Contains(_laser.GetTarget().GetComponent<Enemy>()))
            {
                _laser.SetTarget(null);
                _laser.SetDealingDamage(false);
            }
        }
        
    }


}
