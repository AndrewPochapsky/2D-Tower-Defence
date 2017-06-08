using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower {

    public static int buildCost = 100;
    private void Awake()
    {
        SetStats(TowerType.Type.ARROW, "Arrow Tower", 5, 0, 1, 8, buildCost, 1, 100, 1);
    }

    // Use this for initialization
    protected override void Start () {
        base.Start();
    }

    public override void Upgrade()
    {
        base.Upgrade();
        print("arrow tower upgrading");
        Damage += 2;
        FireRate -= 0.1f;
        UpgradeCost += 150;
        range.IncreaseRange(0.25f);
    }
	
	
	
}
