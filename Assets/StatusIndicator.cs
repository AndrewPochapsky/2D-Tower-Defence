using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    public Text healthText;
    Canvas canvas;
    Enemy enemy;

	// Use this for initialization
	void Start () {
        canvas = transform.GetChild(0).GetComponent<Canvas>();
        enemy = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = enemy.GetHealthString();
	}
}
