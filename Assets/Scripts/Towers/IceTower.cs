using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower {
    public static int buildCost = 400;
    private AoeRange aoeRange;
    private ParticleSystem system;
    private void Awake()
    {
        SetStats(Type.ICE, "Ice Tower", 1, 0, 1, 8, buildCost, 1, 300, 3);
    }

    protected override void Start () {
        aoeRange = transform.GetChild(0).GetComponent<AoeRange>();
        system = transform.GetChild(1).GetComponent<ParticleSystem>();
        
        aoeRange.SetDamage(Damage);
       // StartCoroutine(AlternatingAttack());
    }
	
	// Update is called once per frame
	protected override void Update () {
		
	}

    protected override void Fire()
    {
        
    }
    /*
    private IEnumerator AlternatingAttack()
    {
        system.gameObject.SetActive(false);
        yield return new WaitForSeconds(0);
        system.gameObject.SetActive(true);
        print("slowing");
        aoeRange.Fire();
        StartCoroutine(AlternatingAttack());
    }*/

}
