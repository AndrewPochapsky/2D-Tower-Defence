using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Tower {
    public static int buildCost = 400;
    private List<AoeRange> aoeRanges;
   
    SpriteRenderer towerSP;
    private void Awake()
    {
        SetStats(Type.ICE, "Ice Tower", 1, 0, 1, 8, buildCost, 1, 300, 3);
    }

    protected override void Start () {
        //TODO create a method called initialize with all of these generic references if there become more of them
        gm = GameObject.FindObjectOfType<GameManager>();
        towerSP = GetComponent<SpriteRenderer>();
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
        towerSP.enabled = true;
        UIController.SetDisplayCard(value);
    }


}
