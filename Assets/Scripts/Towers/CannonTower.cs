using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower {
    
	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetStats(TowerType.Type.CANNON, "Cannon Tower", 7,1, 1.5f,8, 200, 1);
	}
	
	
}
