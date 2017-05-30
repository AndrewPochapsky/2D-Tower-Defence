using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower {

	// Use this for initialization
	void Start () {
        SetStats(TowerType.Type.CANNON, "Cannon Tower", 150, 10, 1.5f, 200, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
