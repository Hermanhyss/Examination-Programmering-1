using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesToKill = 5; // Set the number of enemies to kill before progressing to the next level
    private int enemiesKilled = 0;
    public GameObject gameOverUI;

    void Update()
    {
        // Check if the required number of enemies are killed
        if (enemiesKilled >= enemiesToKill)
        {
            ProgressToNextLevel();
        }

        if (gameOverUI.activeInHierarchy) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
      
    }
   void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void gameOver()
    { 
        gameOverUI.SetActive(true); 
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    // Call this method whenever an enemy is killed
    public void EnemyKilled()
    {
        enemiesKilled++;

        // You can add additional logic here, like updating UI or playing sound effects
    }

    void ProgressToNextLevel()
    {
        // Load the next scene or level
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if there is a next scene available
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels available. Game Over!");
            // You can add additional logic for game completion
        }
    }
}

