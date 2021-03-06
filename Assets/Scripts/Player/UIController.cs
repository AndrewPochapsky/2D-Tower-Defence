﻿using System.Collections;
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
    Text waveText, healthText, currencyText, rightClickText;
    private GameObject towerImage= null;
    Text towerName, upgradeLevel, upgradeCost;
    Button upgradeButton;
    public Button startButton;
    GameManager gm;
    public Transform infoCard;
    public BoxCollider2D infoCardColl;

    private static bool displayCard = false;
    
    public static Type currentTowerToBuild;
	

	void Start () {
        currentTowerToBuild = Type.NONE_SELECTED;
        gm = GameObject.FindObjectOfType<GameManager>();
        buttons = new List<Button>();
        canvas = GameObject.FindObjectOfType<Canvas>();

        towerName = infoCard.GetChild(1).GetComponent<Text>();
        upgradeLevel = infoCard.GetChild(2).GetComponent<Text>();
        upgradeCost = infoCard.GetChild(3).GetComponent<Text>();
        upgradeButton = infoCard.GetChild(4).GetComponent<Button>();
        pressedColor = Color.grey;
        for(int i = 0; i < canvas.transform.childCount; i++)
        {
            if (canvas.transform.GetChild(i).GetComponent<Button>())
            {
                Button button = canvas.transform.GetChild(i).GetComponent<Button>();
                if (!button.CompareTag("StartButton"))
                {
                    button.transform.GetChild(1).GetComponent<Text>().text = GetTowerBuildCost(button.gameObject.tag).ToString();
                    buttons.Add(button);
                }
                
            }
                
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        print("number of buttons: " + buttons.Count);
        CheckIfCanBuild();
        CheckIfCanUpgrade();
        if (Input.GetMouseButtonDown(1)&& towerImage!=null)
        {
            ResetTowerUI();
        }

        waveText.text = "Wave: "+ WaveSpawner.GetWaveText();
        healthText.text = "Base Health: " + gm.GetCurrentHealth() + "/" + gm.GetMaxHealth();
        currencyText.text = "Currency: " + gm.GetCurrency();

        
        if(towerImage != null)
        {
            Vector3 v3 = Input.mousePosition;
            v3.z = 10;
            v3 = Camera.main.ScreenToWorldPoint(v3);
            towerImage.transform.position = v3;
            rightClickText.gameObject.SetActive(true);
        }
        else
        {
            rightClickText.gameObject.SetActive(false);
        }
        if (displayCard)
        {
            infoCardColl.enabled = true;
            infoCard.gameObject.SetActive(true);
            towerName.text = MouseRay.lastTower.GetName();
            upgradeLevel.text = "Upgrade Level: " + MouseRay.lastTower.GetUpgradeLevel() + "/"+ Tower.GetMaxUpgradeLevel();
            upgradeCost.text = "Upgrade Cost: " + MouseRay.lastTower.GetUpgradeCost();
        }
        else
        {
            infoCardColl.enabled = false;
            infoCard.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Space)&& startButton.IsInteractable())
        {
            StartWave();
        }

	}

    public void SetCurrentTowerToBuild()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        FindPressedButton(buttons, button.tag);
        currentTowerToBuild = (Type)System.Enum.Parse(typeof(Type), button.tag);
        Destroy(towerImage);
        towerImage = Instantiate(Resources.Load("Towers/TowerImages/"+button.tag + "-Image"), Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation) as GameObject;

    }

    public void FindPressedButton(List<Button> buttons, string tag)
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
        FindPressedButton(buttons,"Bleh");
        rightClickText.gameObject.SetActive(false);
        currentTowerToBuild = Type.NONE_SELECTED;
        Destroy(towerImage);
    }

    public static void SetDisplayCard(bool value)
    {
        displayCard = value;
    }
    //TODO check this only when there is a currency change
    private void CheckIfCanBuild()
    {
        foreach(Button button in buttons)
        {
            string tag = button.tag;
            int buildCost = GetTowerBuildCost(tag);

            Image image = button.transform.GetChild(0).GetComponent<Image>();
            Text text = button.transform.GetChild(1).GetComponent<Text>();
            Color imageColor = image.color;
            Color textColor = text.color;
            if (buildCost > gm.GetCurrency())
            {
                button.interactable = false;
                textColor.a = 0.5f;
                imageColor.a = 0.5f;
               
            }
            else
            {
                button.interactable = true;
                textColor.a = 1;
                imageColor.a = 1;
            }
            image.color = imageColor;
            text.color = textColor;
        }
    }
    private void CheckIfCanUpgrade()
    {
        if(MouseRay.lastTower!=null)
        {
            if(MouseRay.lastTower.GetUpgradeCost() > gm.GetCurrency() || MouseRay.lastTower.GetUpgradeLevel()==Tower.GetMaxUpgradeLevel())
                upgradeButton.interactable = false;
            else
                upgradeButton.interactable = true;

        }
       
    }

    public void DeleteTower()
    {
        gm.IncreaseCurrency(MouseRay.lastTower.GetBuildCost() / 2);
        
        MouseRay.lastTower.Remove();
        MouseRay.lastTower = null;
        print("Setting info card to invisible");
        displayCard = false;
    }
    public void UpgradeTower()
    {
        MouseRay.lastTower.Upgrade();
    }
    private int GetTowerBuildCost(string tag)
    {
        int buildCost = 0;
        switch (tag)
        {
            case "ARROW":
                buildCost = ArrowTower.buildCost;
                break;
            case "LASER":
                buildCost = LaserTower.buildCost;
                break;
            case "CANNON":
                buildCost = CannonTower.buildCost;
                break;
            case "ICE":
                buildCost = IceTower.buildCost;
                break;
        }
        return buildCost;
    }

    public void StartWave()
    {
        WaveSpawner.spawnState = WaveSpawner.SpawnState.COUNTING;
        //startButton.gameObject.SetActive(false);
        startButton.transform.GetChild(0).GetComponent<Text>().text = "Wave in Progress";
        startButton.interactable = false;
    }
    public void EnableStartButton()
    {

        startButton.transform.GetChild(0).GetComponent<Text>().text = "Start Wave";
        startButton.interactable = true;
    }


}
