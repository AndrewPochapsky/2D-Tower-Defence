using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    private Transform exit;
    private Tower tower;
    [HideInInspector]
    public float ProjectileSpeed;
    [HideInInspector]
    public int DamageSpread;
    [HideInInspector]
    public int Damage;
    [HideInInspector]
    public float NextFire;
    [HideInInspector]
    public float FireRate;
    [HideInInspector]
    public Type type;


	// Use this for initialization
	void Start () {
        exit = transform.GetChild(0);
        tower = transform.parent.GetChild(1).GetComponent<Tower>();
	}
	
	// Update is called once per frame
	void Update () {
        if (tower.GetTarget() != null)
        {
            LookAtTarget(tower.GetTarget().transform);
            Fire();
        }
          

	}

    public void Fire()
    {
        if (Time.time > NextFire)
        {
            GameObject obj = Instantiate(Resources.Load("Projectiles/" + type), exit.position, exit.rotation) as GameObject;
            Projectile projectile = obj.GetComponent<Projectile>();

            projectile.SetDamage(Damage);
            projectile.SetDamageSpread(DamageSpread);
            projectile.SetSpeed(ProjectileSpeed);
            projectile.SetTarget(tower.GetTarget().transform);

            NextFire = Time.time + FireRate;

        }
    }
    private void LookAtTarget(Transform target)
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);
    }


}
