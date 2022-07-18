using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadScene(int index)
    {
        ResumeGame();
        SceneManager.LoadScene(index);
    }

    public void LoadNextScene()
    {
        int sceneLoaded = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneLoaded + 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
