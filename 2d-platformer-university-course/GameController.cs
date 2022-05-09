using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool gamePaused = false;
    [SerializeField] private GameObject musicSource;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            } 
            else
            {
                PauseGame();
            }
        }
    }

    private void StartCoroutine(object v)
    {
        throw new NotImplementedException();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        musicSource.GetComponentInChildren<AudioSource>().Play();
        SceneManager.UnloadSceneAsync(3);
        gamePaused = !gamePaused;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        musicSource.GetComponentInChildren<AudioSource>().Pause();
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        gamePaused = !gamePaused;
    }


    public void QuitGame()
    {
        Debug.Log("Saiu do jogo!");
        Application.Quit();
    }


}
