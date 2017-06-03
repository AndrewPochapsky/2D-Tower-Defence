using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

    //TODO: create tower type null or something so you wont build anything when starting out by a click

    Canvas canvas;
    List<Button> buttons;
    Color pressedColor;
    [SerializeField]
    Text healthText, currencyText;
    private GameObject towerImage= null;

    GameManager gm;

    public static TowerType.Type currentTowerToBuild;
	// Use this for initialization
	void Start () {
        currentTowerToBuild = TowerType.Type.NONE_SELECTED;
        gm = GameObject.FindObjectOfType<GameManager>();
        buttons = new List<Button>();
        canvas = GameObject.FindObjectOfType<Canvas>();
        
        pressedColor = Color.grey;
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
        healthText.text = "Base Health: " + gm.GetCurrentHealth() + "/" + gm.GetMaxHealth();
        if(towerImage != null)
        {
            Vector3 v3 = Input.mousePosition;
            v3.z = 10;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            towerImage.transform.position = v3;
        }
	}

    public void SetCurrentTowerToBuild()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        FindPressedButton(button.tag);
        currentTowerToBuild = (TowerType.Type)System.Enum.Parse(typeof(TowerType.Type), button.tag);
        Destroy(towerImage);
        towerImage = Instantiate(Resources.Load("Towers/TowerImages/"+button.tag + "-Image"), Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation) as GameObject;

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

    public void ResetTowerUI()
    {
        FindPressedButton("Bleh");
        currentTowerToBuild = TowerType.Type.NONE_SELECTED;
        Destroy(towerImage);
    }

}
