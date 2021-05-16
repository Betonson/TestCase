﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject restartPanel;
    public GameObject pauseButton;
    public void GoToGameScene()
    {
        SceneManager.LoadScene("TinyPlanets");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ContinueButton()
    {
        //restartPanel.SetActive(false);
        //pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void GoToMainMenuButton()
    {
        //SceneManager.LoadScene("Main menu");
        Debug.Log("Went to main menu");
    }

    public void PauseButton()
    {
        restartPanel.SetActive(true);
        //pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
}
