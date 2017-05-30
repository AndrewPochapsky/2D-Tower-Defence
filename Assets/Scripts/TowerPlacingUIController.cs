using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerPlacingUIController : MonoBehaviour {

    Canvas canvas;
    List<Button> buttons;
    Color pressedColor;


    public static TowerType.Type currentTowerToBuild;
	// Use this for initialization
	void Start () {
        buttons = new List<Button>();
        canvas = GameObject.FindObjectOfType<Canvas>();
        pressedColor = Color.black;
        for(int i = 0; i < canvas.transform.childCount; i++)
        {
            if (canvas.transform.GetChild(i).GetComponent<Button>())
            {
                buttons.Add(canvas.transform.GetChild(i).GetComponent<Button>());
            }
                
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        //print("Current tower to build: " + currentTowerToBuild);
	}

    public void SetCurrentTowerToBuild()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        FindPressedButton(button.tag);
        currentTowerToBuild = (TowerType.Type)System.Enum.Parse(typeof(TowerType.Type), button.tag);
    }

    private void FindPressedButton(string tag)
    {
        foreach(Button button in buttons)
        {
            if (button.CompareTag(tag))
            {
                button.GetComponent<Image>().color = pressedColor;
            }
            else
            {
                button.GetComponent<Image>().color = Color.white;
            }
        }
    }

}
