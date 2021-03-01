using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Text textHealth;

    public int currentGold;
    public int startGold;
    public Text textGold;

    // Start is called before the first frame update
    void Start()
    {
        //start every game with the max amount of health
        currentHealth = maxHealth;
        //set the textHealth with the string "Health" followed by the number of healthPoints
        textHealth.text = "Health: " + currentHealth.ToString();


        currentGold = startGold;
        DisplayGold();
    }

    public void BuyTower()
    {
        currentGold--;
        DisplayGold();
    }

    public void SellTower()
    {
        currentGold++;
        DisplayGold();
    }



    //the amount of damage taken by enemies
    public void TakeDamage(int amountOfDamage)
    {
        currentHealth = currentHealth - amountOfDamage;
        textHealth.text = "Health: " + currentHealth.ToString();
    }


    public void ReceiveGold(int amountOfGold)
    {
        currentGold = currentGold + amountOfGold;
        DisplayGold();
    }


    void DisplayGold()
    {
        textGold.text = "Gold: " + currentGold.ToString();
    }
}
