using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public int wave;
    public float nextWaveIn;

    public GameObject[] enemyList;
    public Text nextWaveTimer;


    // Update is called once per frame
    void Update()
    {
        //decrease timer for next wave per second
        nextWaveIn -= Time.deltaTime;

        //displays timer on screen
        nextWaveTimer.text = "Next Wave in: " + Mathf.Round(nextWaveIn);

        //check for the next wave; if timer for next wave is <= 0; spawn new wave, reset timer
        if (nextWaveIn <= 0)
        {
            nextWaveIn = 5f;
            Instantiate(enemyList[0], transform.position,Quaternion.identity);
        }
    }
}
