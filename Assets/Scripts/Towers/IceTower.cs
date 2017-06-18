using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower {
    public static int buildCost = 550;
    private List<AoeRange> aoeRanges;
   
   
    private void Awake()
    {
        SetStats(Type.ICE, "Ice Tower", 1, 0, 1, 8, buildCost, 1, 300, 3);
    }

    protected override void Start () {
        //TODO create a method called initialize with all of these generic references if there become more of them
        sp = GetComponent<SpriteRenderer>();
        gm = GameObject.FindObjectOfType<GameManager>();
       
        aoeRanges = new List<AoeRange>();
        foreach(AoeRange range in transform.GetComponentsInChildren<AoeRange>())
        {
            aoeRanges.Add(range);
            range.SetDamage(Damage);
        }
       
        
        
       // StartCoroutine(AlternatingAttack());
    }
	
	// Update is called once per frame
	protected override void Update () {
		
	}

   

    public override void ToggleInfo(bool value)
    {
        foreach(SpriteRenderer sp in GetComponentsInChildren<SpriteRenderer>())
        {
            print("ha");
            sp.enabled = value;
        }
        sp.enabled = true;
        UIController.SetDisplayCard(value);
    }

    public override void Upgrade()
    {
        base.Upgrade();
        foreach(AoeRange range in aoeRanges)
        {
            range.IncreaseRange(0.25f, 0.25f);
        }
        
        UpgradeCost += 300;
    }
}
