using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLocation : MonoBehaviour {
    UIController ui;
    GameManager gm;
	// Use this for initialization
	void Start () {
        ui = GameObject.FindObjectOfType<UIController>();
        gm = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void PlaceTower(Type type)
    {
        if (type!= Type.NONE_SELECTED && transform.childCount == 0)
        {
            GameObject tower = Instantiate(Resources.Load("Towers/" + type  + "Prefab"), transform.position, transform.rotation) as GameObject;
            tower.transform.SetParent(transform);
            tower.transform.localPosition = new Vector3(0, 3.2f, 0);
            gm.DepleteCurrency(tower.transform.GetChild(1).GetComponent<Tower>().GetBuildCost());
            
            ui.ResetTowerUI();
        }
        else
        {
            print("Tower already exists on location: " + name);
        }
       
        
    }


   

}
