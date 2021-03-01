using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableTile : MonoBehaviour
{

    public bool isTowerPlaced;
    public SpriteRenderer tower;


    // Start is called before the first frame update
    void Start()
    {
        tower.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!tower.enabled)
            isTowerPlaced = false;
        else
            isTowerPlaced = true;
    }



    public void BuildingTower()
    {
        if (isTowerPlaced)
        {
            Debug.Log("There is already a tower Built!");

        }
        else
        {
            tower.enabled = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().BuyTower();
        }

    }

    public void SellingTower()
    {
        if (!isTowerPlaced)
            Debug.Log("No Tower to sell here!");
        else
            tower.enabled = false;
    }
}
