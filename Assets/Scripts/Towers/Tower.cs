using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    protected string Name { get; set; }
    protected int Damage { get; set; }
    protected float FireRate { get; set; }
    protected float NextFire { get; set; }

    protected int BuildCost { get; set; }
    protected int UpgradeLevel { get; set; }
    protected TowerType.Type Type { get; set; }

    private Enemy target;
    private TowerRange range;
    private Transform cannon;


    protected virtual void Start()
    {
        range = transform.GetChild(0).GetComponent<TowerRange>();
        cannon = transform.GetChild(1).transform;
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

    protected void SetStats(TowerType.Type type, string name, int damage, float fireRate, int buildCost, int upgradeLevel)
    {
        Type = type;
        Name = name;
        Damage = damage;
        FireRate = fireRate;
        BuildCost = buildCost;
        UpgradeLevel = upgradeLevel;
    }
    private void Fire()
    {
        if (range.GetEnemy() != null)
        {
            
        }
    }

}
