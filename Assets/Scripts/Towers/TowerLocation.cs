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

    public void PlaceTower(TowerType.Type type)
    {
        if (transform.childCount == 0)
        {
            GameObject tower = Instantiate(Resources.Load("Towers/" + type), transform.position, transform.rotation) as GameObject;
            tower.transform.SetParent(transform);
            int buildCost;
            switch (type)
            {
                case TowerType.Type.ARROW:
                    buildCost = ArrowTower.buildCost;
                    break;
                case TowerType.Type.WIZARD:
                    
                    break;
                case TowerType.Type.LASER:
                    buildCost = LaserTower.buildCost;
                    break;
                case TowerType.Type.CANNON:
                    buildCost = CannonTower.buildCost;
                    break;

            }
            gm.DepleteCurrency(tower.GetComponent<Tower>().GetBuildCost());
            
            ui.ResetTowerUI();
        }
        else
        {
            print("Tower already exists on location: " + name);
        }
       
        
    }


   

}
