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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Enemy target = collision.GetComponent<Enemy>();
            if(projectile is CannonBall)
            {
                //print("projectile is cannon ball");
                CannonBall proj = (CannonBall)projectile;
                if (proj.IsDetonated())
                {

                    target.DealDamage(damage);
                    print("target: " + target);
                    Destroy(projectile.gameObject);
                }
                
            }
        }
    }

}
