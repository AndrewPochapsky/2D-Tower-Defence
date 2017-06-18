using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsUltra : Enemy{

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetUpStats("Cyclops Ulra", 450, 10, 0.75f, 150);
    }
	
}
