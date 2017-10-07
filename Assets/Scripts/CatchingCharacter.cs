using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CatchingCharacter : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Toggle pauseMenu = (Toggle)FindObjectOfType(typeof(Toggle));
            pauseMenu.interactable = false;
            Instantiate(gameOverMenu);
            Time.timeScale = 0f;
        }
    }
}
