using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

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
    protected Type Type { get; set; }
    protected GameManager gm;
    protected Enemy[] targets;
    
    public Cannon cannon;
    protected TowerRange range;
    


    protected virtual void Start()
    {
        range = transform.GetChild(0).GetComponent<TowerRange>();
        targets = new Enemy[NumOfTargets];
        range.SetNumOfTargets(NumOfTargets);
        
        gm = GameObject.FindObjectOfType<GameManager>();
        cannon.Damage = Damage;
        cannon.DamageSpread = DamageSpread;
        cannon.FireRate = FireRate;
        cannon.NextFire = NextFire;
        cannon.type = Type;
        cannon.ProjectileSpeed = ProjectileSpeed;
        
    }

    protected virtual void Update()
    {
        targets = range.GetEnemies();
        //print("Targets count: " + targets.Length);
        //print("Next Fire: " + NextFire);
        if (targets.Length == 1)
        {
            if (targets[0] != null)
            {
                cannon.Fire();
            }
        }
       
        
    }

    public virtual void Remove()
    {
        transform.parent.parent.GetComponent<SpriteRenderer>().enabled = true;
        transform.parent.parent.GetComponent<Collider2D>().enabled = true;
        Destroy(transform.parent.gameObject);
    }

    public virtual void Upgrade()
    {
        //TODO increment stats in some way, maybe make this a virtual function, probs best idea
        UpgradeLevel++;
        gm.DepleteCurrency(UpgradeCost);
        
    }

    protected void SetStats(Type type, string name, int damage, int damageSpread, float fireRate, float projectileSpeed, int buildCost, int upgradeLevel, int upgradeCost, int numOfTargets)
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
    }/*
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


    }*/
    public Enemy GetTarget()
    {
        return targets[0];
    }
    public virtual void ToggleInfo(bool value)
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
