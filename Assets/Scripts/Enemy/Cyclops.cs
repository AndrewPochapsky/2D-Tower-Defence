using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : Enemy {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetUpStats("Cyclops", 150, 5, 0.65f, 75);
    }
	
	
}
