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
    public void LoadScene2(int index)
    {
            ResumeGame();
            GameObject.Find("DDOL").GetComponent<DDOL>().DestroyObject();
            SceneManager.LoadScene(index);
    }

    public void LoadNextScene()
    {
        TLS_GameManager.instance.UIManager.skullCount = 0;
        TLS_GameManager.instance.UIManager.skullCountText.text = TLS_GameManager.instance.UIManager.skullCount.ToString() + " / " + TLS_GameManager.instance.UIManager.totalSkullCount;

        int sceneLoaded = SceneManager.GetActiveScene().buildIndex;

        if(sceneLoaded > 1)
        {
                GameObject.Find("EnemySpawner").GetComponent<TLS_EnemySpawner>().StopDeploying();
        }

        SceneManager.LoadScene(4);
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
