using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetUpStats("Spider", 5, 2, 3);
    }
	
	
}
