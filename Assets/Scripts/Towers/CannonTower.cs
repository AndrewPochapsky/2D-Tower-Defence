using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetStats(TowerType.Type.CANNON, "Cannon Tower", 10, 1.5f, 200, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
