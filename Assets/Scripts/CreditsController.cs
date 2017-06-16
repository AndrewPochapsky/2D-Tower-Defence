using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {
    bool display = false;
    public RectTransform creditsPanel;
	
	// Update is called once per frame
	void Update () {
        creditsPanel.gameObject.SetActive(display);
	}

    public void ToggleDisplay()
    {
        display = !display;
    }




}
