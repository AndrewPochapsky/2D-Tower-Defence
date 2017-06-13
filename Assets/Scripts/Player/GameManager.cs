using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    LevelManager levelManager;

    private int maxHealth;
    private int currentHealth;
    private int currencyAmount;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        maxHealth = 50;
        currentHealth = maxHealth;
        currencyAmount = 10000;
        
	}

    private void Update()
    {
        if(currentHealth <= 0)
        {
            EndGame();
        }   
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetMaxHealth(int health)
    {
        maxHealth = health;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public void SetCurrentHealth(int health)
    {
        currentHealth = health;
    }

    public int GetCurrency()
    {
        return currencyAmount;
    }
    public void DepleteCurrency(int amount)
    {
        currencyAmount -= amount;
    }
    public void IncreaseCurrency(int amount)
    {
        currencyAmount += amount;
    }

    private void EndGame()
    {
        levelManager.LoadLevel("02End");
    }

}
