using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenuControl : MonoBehaviour
{
    public void ExitAplication()
    {
        Application.Quit();
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
