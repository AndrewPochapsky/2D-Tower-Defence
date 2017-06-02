using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour {

   

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
        print("Raycasting: "+hit.collider.name);
        if (hit.collider!= null && hit.collider.gameObject.GetComponent<TowerLocation>())
        {
            
            TowerLocation loc = hit.collider.gameObject.GetComponent<TowerLocation>();
            loc.PlaceTower(UIController.currentTowerToBuild);

        }
      

    }


}
