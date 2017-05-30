using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    protected string Name { get; set; }
    protected int Damage { get; set; }
    protected float FireRate { get; set; }

    protected int BuildCost { get; set; }
    protected int UpgradeLevel { get; set; }
    protected TowerType.Type Type { get; set; }

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


}
