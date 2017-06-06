using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int maxHealth;
    private int currentHealth;
    private int currencyAmount;

    // Use this for initialization
    void Start () {
        maxHealth = 50;
        currentHealth = maxHealth;
        currencyAmount = 500;
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

}
