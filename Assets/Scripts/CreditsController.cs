using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {
    bool display = false;
    public RectTransform creditsPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        creditsPanel.gameObject.SetActive(display);
	}

    public void ToggleDisplay()
    {
        display = !display;
    }




}
