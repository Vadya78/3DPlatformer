using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    Light lampLight;
    public float switchingTime = 3f;

    void Start ()
    {
        lampLight = GetComponentInChildren<Light>();
        InvokeRepeating("LightSwitching", 0f, switchingTime);
    }

    private void LightSwitching()
    {
        if (Time.timeScale != 0)
        {
            lampLight.gameObject.SetActive(!lampLight.gameObject.activeSelf);
        }
    }
}
