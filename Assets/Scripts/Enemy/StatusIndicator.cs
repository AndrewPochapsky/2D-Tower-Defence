using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour {

    [SerializeField]
    private RectTransform healthBar;
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


    public void SetHealth()
    {
        float value = (float)enemy.GetCurrentHealth() / enemy.GetMaxHealth();
        healthBar.localScale = new Vector3(value, healthBar.localScale.y, healthBar.localScale.z);
    }

}
