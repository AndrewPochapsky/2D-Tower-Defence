using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Projectile {
    DamageSpread spread;
    private bool detonated = false;
    protected override void Start()
    {
        base.Start();
        spread = transform.GetChild(0).GetComponent<DamageSpread>();
        spread.SetDamage(damageSpread);

    }
    protected override void Update()
    {
        base.Update();
        if (detonated)
        {
            print("Detonated");
        }
    }
    public bool IsDetonated()
    {
        return detonated;
    }
    public void SetDetonated(bool b)
    {
        detonated = b;
    }
}
