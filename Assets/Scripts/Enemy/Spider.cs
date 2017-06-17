using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy {

	// Use this for initialization
	protected override void Start () {
        base.Start();
        SetUpStats("Spider", 5, 2, 3, 15);
    }


    protected override void SetSprites()
    {
        switch (DirectionMoving())
        {
            case "up":
                body.sprite = bodyBack;
                break;
            case "down":
                body.sprite = bodyFront;
                break;
            case "right":
                body.sprite = bodyRight;
                break;
            case "left":
                body.sprite = bodyLeft;
                break;
        }
    }

}
