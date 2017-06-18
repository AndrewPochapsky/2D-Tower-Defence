using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower {

    public static int buildCost = 250;
    private void Awake()
    {
        SetStats(Type.CANNON, "Cannon Tower", 6, 1, 1.4f, 8, buildCost, 1, 200, 1);
    }

    // Use this for initialization
    protected override void Start () {
       
        base.Start();
    }
    public override void Upgrade()
    {
        base.Upgrade();
        Damage += 2;
        DamageSpread += 1;
        FireRate -= 0.1f;
        UpgradeCost += 200;
        range.IncreaseRange(0.2f);
    }


}
