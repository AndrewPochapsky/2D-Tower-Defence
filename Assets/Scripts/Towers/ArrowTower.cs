using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetStats(TowerType.Type.ARROW, "Arrow Tower", 5,0, 1,8, 50, 1);
	}
	
	
	
}
