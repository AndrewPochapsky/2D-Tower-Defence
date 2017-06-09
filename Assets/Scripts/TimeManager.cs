using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TimeManager : MonoBehaviour {

    private Transform buttonContainer;
    private List<Button> buttons;
    private EventSystem eventSystem;
    private UIController uiController;

	// Use this for initialization
	void Start () {
        uiController = GameObject.FindObjectOfType<UIController>();
        eventSystem = GameObject.FindObjectOfType<EventSystem>();
        buttons = new List<Button>();
        buttonContainer = GameObject.FindGameObjectWithTag("TimeButtons").transform;
        foreach(Button button in buttonContainer.GetComponentsInChildren<Button>())
        {
            buttons.Add(button);
        }
      

    }
	
	// Update is called once per frame
	void Update () {
        	
	}

    public void SetTime()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        uiController.FindPressedButton(buttons, button.tag);

        switch (button.tag)
        {
            case "Normal":
                Time.timeScale = 1;
                break;
            case "Faster":
                Time.timeScale = 1.5f;
                break;
            case "Fastest":
                Time.timeScale = 3;
                break;
        }

    }

   




}
