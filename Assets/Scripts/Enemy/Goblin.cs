using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetUpStats("Goblin", 15, 1, 1, 25);
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}
}
