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
        print("Casting ray fromo mouse");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider!= null && hit.collider.gameObject.GetComponent<TowerLocation>())
        {
            Debug.Log("Tower Location");
            TowerLocation loc = hit.collider.gameObject.GetComponent<TowerLocation>();
            loc.PlaceTower(TowerPlacingUIController.currentTowerToBuild);

        }
      

    }


}
