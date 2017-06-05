using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpread : MonoBehaviour {

    private int damage;
    [HideInInspector]
    public Projectile projectile;
    private void Start()
    {
        projectile = transform.parent.GetComponent<Projectile>();
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
   

}
