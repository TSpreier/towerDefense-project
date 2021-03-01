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

    public bool isGameStarted;

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            //decrease timer for next wave per second
            nextWaveIn -= Time.deltaTime;

            //displays timer on screen
            nextWaveTimer.text = "Next Wave in: " + Mathf.Round(nextWaveIn);

            //check for the next wave; if timer for next wave is <= 0; spawn new wave, reset timer
            if (nextWaveIn <= 0)
            {
                //reset the waveTimer
                nextWaveIn = 5f;
                //Spawn the enemy from the enemyList at the position where this GameObject is, with the same rotation as this gameObject
                Instantiate(enemyList[0], transform.position, Quaternion.identity);
            }
        }
        else
        {
            nextWaveTimer.text = "Press Start to begin the game.";
        }
    }


    public void SpawnNextWave()
    {
        nextWaveIn = 0;
    }
}
