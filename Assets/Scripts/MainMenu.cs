using System;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        DeathScreen.GameOver = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
