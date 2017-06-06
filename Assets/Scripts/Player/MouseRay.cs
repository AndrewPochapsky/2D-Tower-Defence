using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour {

    public static Tower lastTower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
            CastRay();
	}

    private void CastRay()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit.collider!=null)
            print("Raycasting: "+hit.collider.name);
        if (hit.collider!= null)
        {
            CheckIfDisplayTowerInfo(hit);
            CheckIfBuildTower(hit);

        }
        else
        {
            if(lastTower!=null)
                lastTower.ToggleInfo(false);
        }
      

    }

    private void CheckIfBuildTower(RaycastHit2D hit)
    {
        if (hit.collider.gameObject.GetComponent<TowerLocation>())
        {
            TowerLocation loc = hit.collider.GetComponent<TowerLocation>();
            loc.PlaceTower(UIController.currentTowerToBuild);
        }
    }

    private void CheckIfDisplayTowerInfo(RaycastHit2D hit)
    {
        //display tower card which will contain stats and upgrade option
        if (hit.collider.gameObject.GetComponent<Tower>())
        {
            if (lastTower != null)
            {
                lastTower.ToggleInfo(false);
            }
            Tower tower = hit.collider.GetComponent<Tower>();
            lastTower = tower;
            tower.ToggleInfo(true);
            
        }
    }

}
