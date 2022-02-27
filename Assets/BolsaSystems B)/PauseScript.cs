using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public Image pauseScreen;
    private bool isPaused;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}