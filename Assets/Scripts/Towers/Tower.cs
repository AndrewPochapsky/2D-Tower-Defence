using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    protected string Name { get; set; }
    protected int Damage { get; set; }
    protected int DamageSpread { get; set; }
    protected float FireRate { get; set; }
    protected float NextFire { get; set; }
    protected float ProjectileSpeed { get; set; }
   

    protected int BuildCost { get; set; }
    protected int UpgradeLevel { get; set; }
    protected TowerType.Type Type { get; set; }

    private Enemy target;
    
    private Transform cannon;
    private TowerRange range;


    protected virtual void Start()
    {
        range = transform.GetChild(1).GetComponent<TowerRange>();
        cannon = transform.GetChild(0).transform;
    }

    protected virtual void Update()
    {
        target = range.GetEnemy();
        //print("Next Fire: " + NextFire);
       if(target != null)
        {
            Fire();
        }
    }

    protected void Remove()
    {
        Destroy(gameObject);
    }

    protected void Upgrade()
    {
        //increase stats
        UpgradeLevel++;
    }

    protected void SetStats(TowerType.Type type, string name, int damage, int damageSpread, float fireRate, float projectileSpeed, int buildCost, int upgradeLevel)
    {
        Type = type;
        Name = name;
        Damage = damage;
        DamageSpread = damageSpread;
        FireRate = fireRate;
        ProjectileSpeed = projectileSpeed;
        BuildCost = buildCost;
        UpgradeLevel = upgradeLevel;
    }
    private void Fire()
    {
        //print("New Next Fire: " + NextFire);
        if (Time.time > NextFire)
        {
            GameObject obj = Instantiate(Resources.Load("Projectiles/" + Type), cannon.position, cannon.rotation) as GameObject;
            Projectile projectile = obj.GetComponent<Projectile>();

            projectile.SetDamage(Damage);
            projectile.SetDamageSpread(DamageSpread);
            projectile.SetSpeed(ProjectileSpeed);
            projectile.SetTarget(target.transform);
            
            NextFire = Time.time + FireRate;
            
        }


    }
   

  
}
