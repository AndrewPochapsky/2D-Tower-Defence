using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : Enemy {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetUpStats("Troll", 50, 5, 0.5f, 50);
    }
	
	
}
