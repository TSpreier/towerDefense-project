using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    int health;
    public int damage;
    public int gold;

    //the amaount of damage, which will deal the enemy to the player
    public void DealDamage(int amountOfDamage)
    {
        //find a gameobject with the tag "Player", get the "PlayerStats" component from 
        //it and call the "TakeDamage" method with the int parameter
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().TakeDamage(amountOfDamage);
    }

    public void GiveGold(int amountOfGold)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().ReceiveGold(gold);
    }


}
