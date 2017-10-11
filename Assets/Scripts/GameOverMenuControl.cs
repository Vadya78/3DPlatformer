using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameOverMenuControl : MonoBehaviour
{
    public GameObject gameOverMenu;

    public static void GamePauseStatusChange()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void ExitAplication()
    {
        Application.Quit();
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
        GamePauseStatusChange();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GamePauseStatusChange();
    }

    public void CreateGameOverMenu()
    {
        Toggle pauseMenu = (Toggle)FindObjectOfType(typeof(Toggle));
        pauseMenu.interactable = false;
        Instantiate(gameOverMenu);
        GamePauseStatusChange();
    }

}
