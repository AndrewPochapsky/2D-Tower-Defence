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
        
       
        print("Arrow build cost: " + BuildCost);
        base.Start();
    }
	
	
	
}
