using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerUI : MonoBehaviour
{
    //Try to combine PauseMenu and GameOverMenuControl
    public GameObject gameOverMenu;
    private Toggle menuToggle;
    private static bool pause = false;

    public static void GamePauseStatusChange()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        pause = pause == true ? false : true;
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
        if(menuToggle == null)
        {
            menuToggle = FindObjectOfType<Toggle>();
        }
        //Toggle pauseMenu = (Toggle)FindObjectOfType(typeof(Toggle));
        menuToggle.interactable = false;
        Instantiate(gameOverMenu);
        GamePauseStatusChange();
    }

#if !MOBILE_INPUT
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (menuToggle == null)
            {
                menuToggle = FindObjectOfType<Toggle>();
            }
            menuToggle.isOn = !menuToggle.isOn;
            Cursor.visible = menuToggle.isOn;
        }
    }
#endif
}
