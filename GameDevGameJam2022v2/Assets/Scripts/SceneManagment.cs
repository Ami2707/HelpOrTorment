using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment: MonoBehaviour
{
    int nextScene;
    int currentScene;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void LoadNextScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadNextStartingScene()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextScene = currentScene + 2;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadStartingScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CheckHelpResults()
    {
        if (gameManager.helpCount >= 2)
        {
            Debug.Log("Help count: " + gameManager.helpCount);
            SceneManager.LoadScene(7);
        }
        else
        {
            Debug.Log("Help count: " + gameManager.helpCount);
            SceneManager.LoadScene(8);
        }
    }

}
