using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace TheLastSymphony
{
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

        if(sceneLoaded > 1)
        {
                GameObject.Find("EnemySpawner").GetComponent<TLS_EnemySpawner>().StopDeploying();
        }

        SceneManager.LoadScene(sceneLoaded + 1);
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
}
