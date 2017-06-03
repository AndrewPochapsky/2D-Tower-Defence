using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLocation : MonoBehaviour {
    UIController ui;
	// Use this for initialization
	void Start () {
        ui = GameObject.FindObjectOfType<UIController>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void PlaceTower(TowerType.Type type)
    {
        if (transform.childCount == 0)
        {
            GameObject tower = Instantiate(Resources.Load("Towers/" + type), transform.position, transform.rotation) as GameObject;
            tower.transform.SetParent(transform);
            
            ui.ResetTowerUI();
        }
        else
        {
            print("Tower already exists on location: " + name);
        }
       
        
    }


   

}
