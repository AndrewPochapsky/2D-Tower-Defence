using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTest : MonoBehaviour {
    LineRenderer lineRenderer;
    Transform target;
	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        
        
	}
	
	// Update is called once per frame
	void Update () {
        target = GameObject.FindObjectOfType<Enemy>().transform;
        if(target != null)
        {
            lineRenderer.SetPosition(1, target.position);
            
        }
           
      
	}
}
