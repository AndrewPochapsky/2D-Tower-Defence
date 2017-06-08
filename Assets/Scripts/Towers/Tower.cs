using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private static int maxUpgradeLevel = 3;

    protected string Name { get; set; }
    protected int Damage { get; set; }
    protected int DamageSpread { get; set; }
    protected float FireRate { get; set; }
    protected float NextFire { get; set; }
    protected float ProjectileSpeed { get; set; }
    protected int NumOfTargets { get; set; }

    protected int BuildCost { get; set; }
    protected int UpgradeLevel { get; set; }
    protected int UpgradeCost { get; set; }
    protected TowerType.Type Type { get; set; }
    protected GameManager gm;
    protected Enemy[] targets;
    
    protected Transform cannon;
    protected TowerRange range;
    


    protected virtual void Start()
    {
        range = transform.GetChild(1).GetComponent<TowerRange>();
        targets = new Enemy[NumOfTargets];
        range.SetNumOfTargets(NumOfTargets);
        cannon = transform.GetChild(0).transform;
        gm = GameObject.FindObjectOfType<GameManager>();
       
        
    }

    protected virtual void Update()
    {
        targets = range.GetEnemies();
        print("Targets count: " + targets.Length);
        //print("Next Fire: " + NextFire);
        if (targets.Length == 1)
        {
            if (targets[0] != null)
            {
                Fire();
            }
        }
       
        
    }

    protected void Remove()
    {
        Destroy(gameObject);
    }

    public virtual void Upgrade()
    {
        //TODO increment stats in some way, maybe make this a virtual function, probs best idea
        UpgradeLevel++;
        gm.DepleteCurrency(UpgradeCost);
        
    }

    protected void SetStats(TowerType.Type type, string name, int damage, int damageSpread, float fireRate, float projectileSpeed, int buildCost, int upgradeLevel, int upgradeCost, int numOfTargets)
    {
        Type = type;
        Name = name;
        Damage = damage;
        DamageSpread = damageSpread;
        FireRate = fireRate;
        ProjectileSpeed = projectileSpeed;
        BuildCost = buildCost;
        UpgradeLevel = upgradeLevel;
        UpgradeCost = upgradeCost;
        NumOfTargets = numOfTargets;
    }
    protected virtual void Fire()
    {
        //print("New Next Fire: " + NextFire);
        
        if (Time.time > NextFire)
        {
            GameObject obj = Instantiate(Resources.Load("Projectiles/" + Type), cannon.position, cannon.rotation) as GameObject;
            Projectile projectile = obj.GetComponent<Projectile>();

            projectile.SetDamage(Damage);
            projectile.SetDamageSpread(DamageSpread);
            projectile.SetSpeed(ProjectileSpeed);
            projectile.SetTarget(targets[0].transform);
            
            NextFire = Time.time + FireRate;
            
        }


    }

    public void ToggleInfo(bool value)
    {
        SpriteRenderer sp = range.GetComponent<SpriteRenderer>();
        sp.enabled = value;
        UIController.SetDisplayCard(value);
    }
   
    public string GetName()
    {
        return Name;
    }
    public int GetUpgradeLevel()
    {
        return UpgradeLevel;
    }
    public static int GetMaxUpgradeLevel()
    {
        return maxUpgradeLevel;
    }
    public int GetUpgradeCost()
    {
        return UpgradeCost;
    }
    public int GetBuildCost()
    {
        return BuildCost;
    }
    //TODO maybe make this just return the enemy instead of index
    /*protected Enemy GetTargetableEnemy()
    {

        for(int i =0; i < NumOfTargets; i++)
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
    }*/


}
