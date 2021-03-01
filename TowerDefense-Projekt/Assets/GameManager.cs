using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text fastForwardText;
    public Text normalSpeedText;
    bool isGameFaster;
    public GameObject gameObjectStartGameButton;

    public GameObject gameObjectPauseMenuPanel;
    public GameObject gameObjectUIPanel;
    public GameObject gameObjectConfirmationRestartPanel;
    public GameObject gameObjectConfirmationExitPanel;

    public bool isInMenu;


    // Start is called before the first frame update
    void Start()
    {
        isInMenu = false;
        gameObjectPauseMenuPanel.SetActive(false);
        gameObjectConfirmationRestartPanel.SetActive(false);
        gameObjectConfirmationExitPanel.SetActive(false);
        isGameFaster = false;
        normalSpeedText.enabled = false;
        fastForwardText.enabled = true;

        //start everytime the level with normal speed
        Time.timeScale = 1f;
    }

    //Different game speed modes
    public void FastForwardGame()
    {
        isGameFaster = !isGameFaster;
        if (isGameFaster)
        {
            SetSpeed(1.5f);
            normalSpeedText.enabled = true;
            fastForwardText.enabled = false;

        }
        else
        {
            SetSpeed(1);
            normalSpeedText.enabled = false;
            fastForwardText.enabled = true;
        }
    }



    //sets the current speed of the game
    void SetSpeed(float speed)
    {
        Time.timeScale = speed;
    }


    //Start Game; Start button is in front of Fast Forward Button, so that the player first has to start the game
    //before he/she can speed the game up
    public void StartGame()
    {
        EnemySpawner enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        enemySpawner.isGameStarted = true;
        enemySpawner.SpawnNextWave();
        Destroy(gameObjectStartGameButton);
    }

    //pause the game; disable UI interface, enable pause menu, stop the time
    public void PauseMenu()
    {
        isInMenu = true;
        Time.timeScale = 0f;
        gameObjectPauseMenuPanel.SetActive(true);
        gameObjectUIPanel.SetActive(false);
    }

    //resumes the game
    public void ResumeGame()
    {
        if (isGameFaster)
        {
            SetSpeed(1.5f);
            normalSpeedText.enabled = true;
            fastForwardText.enabled = false;

        }
        else
        {
            SetSpeed(1);
            normalSpeedText.enabled = false;
            fastForwardText.enabled = true;
        }
        isInMenu = false;
        gameObjectPauseMenuPanel.SetActive(false);
        gameObjectUIPanel.SetActive(true);
    }

    //open the confirmation panel for restarting the level
    public void OpenRestartConfirmationPanel()
    {
        gameObjectConfirmationRestartPanel.SetActive(true);
        gameObjectPauseMenuPanel.SetActive(false);
    }

    //closes the confirmation panel for restarting the level
    public void CancelConfirmationRestartPanel()
    {
        gameObjectConfirmationRestartPanel.SetActive(false);
        gameObjectPauseMenuPanel.SetActive(true);
    }

    //restarts the current level
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //open the confirmation panel for leaving the level
    public void OpenExitConfirmationPanel()
    {
        gameObjectConfirmationExitPanel.SetActive(true);
        gameObjectPauseMenuPanel.SetActive(false);
    }

    //closes the confirmation panel for leaving the level
    public void CancelConfirmationExitPanel()
    {
        gameObjectConfirmationExitPanel.SetActive(false);
        gameObjectPauseMenuPanel.SetActive(true);
    }

    //leave the level
    public void ExitGame()
    {
        Debug.Log("Level exit");
    }
}
