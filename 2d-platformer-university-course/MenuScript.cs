using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }

    public void CreditsPage()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Debug.Log("Saiu do jogo!");
        Application.Quit();
    }
}
