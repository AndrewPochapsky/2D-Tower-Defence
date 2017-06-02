using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLocation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void PlaceTower(TowerType.Type type)
    {
        Instantiate(Resources.Load("Towers/"+type), transform.position, transform.rotation);
        
    }


   

}
