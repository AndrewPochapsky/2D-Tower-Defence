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
    Text waveText, healthText, currencyText, rightClickText;
    private GameObject towerImage= null;
    Text towerName, upgradeLevel, upgradeCost;
    Button upgradeButton;
    GameManager gm;
    public Transform infoCard;
    public BoxCollider2D infoCardColl;

    private static bool displayCard = false;
    
    public static TowerType.Type currentTowerToBuild;
	

	void Start () {
        currentTowerToBuild = TowerType.Type.NONE_SELECTED;
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
                buttons.Add(canvas.transform.GetChild(i).GetComponent<Button>());
            }
                
        }
        
	}
	
	// Update is called once per frame
	void Update () {
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
	}

    public void SetCurrentTowerToBuild()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        FindPressedButton(buttons, button.tag);
        currentTowerToBuild = (TowerType.Type)System.Enum.Parse(typeof(TowerType.Type), button.tag);
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
        currentTowerToBuild = TowerType.Type.NONE_SELECTED;
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
            int buildCost=0;
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
            }
            if(buildCost > gm.GetCurrency())
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
    private void CheckIfCanUpgrade()
    {
        if(MouseRay.lastTower!=null)
        {
            if(MouseRay.lastTower.GetUpgradeCost() > gm.GetCurrency() || MouseRay.lastTower.GetUpgradeLevel()==Tower.GetMaxUpgradeLevel())
                upgradeButton.interactable = false;
        }
        else
        {
            upgradeButton.interactable = true;
        }
    }

    public void DeleteTower()
    {
        gm.IncreaseCurrency(MouseRay.lastTower.GetBuildCost() / 2);
        Destroy(MouseRay.lastTower.gameObject);
        MouseRay.lastTower = null;
        print("Setting info card to invisible");
        displayCard = false;
    }
    public void UpgradeTower()
    {
        MouseRay.lastTower.Upgrade();
    }


}
