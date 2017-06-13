using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TimeManager : MonoBehaviour {

    public Text pausedText;
    private float lastTime = 0;
    public RectTransform buttonContainer;
    private List<Button> buttons;
    private EventSystem eventSystem;
    private UIController uiController;

	// Use this for initialization
	void Start () {
        uiController = GameObject.FindObjectOfType<UIController>();
        eventSystem = GameObject.FindObjectOfType<EventSystem>();
        buttons = new List<Button>();
      
        foreach(Button button in buttonContainer.GetComponentsInChildren<Button>())
        {
            buttons.Add(button);
        }

        lastTime = Time.timeScale;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    public void SetTime()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        if(button != null)
        {
            uiController.FindPressedButton(buttons, button.tag);
            switch (button.tag)
            {
                case "Normal":
                    Time.timeScale = 1;
                    lastTime = Time.timeScale;
                    break;
                case "Faster":
                    Time.timeScale = 1.5f;
                    lastTime = Time.timeScale;
                    break;
                case "Fastest":
                    Time.timeScale = 3;
                    lastTime = Time.timeScale;
                    break;
            }
        }
           

       

    }

    private void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            pausedText.gameObject.SetActive(false);
            Time.timeScale = lastTime;
            
        }

        else
        {
            pausedText.gameObject.SetActive(true);
            Time.timeScale = 0;
           
        }
           
    }




}
