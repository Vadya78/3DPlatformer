﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Toggle m_MenuToggle;
    private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    private bool m_Paused = false;

    void Awake ()
    {
        m_MenuToggle = GetComponent<Toggle>();
	}

    public void OnMenuStatusChange()
    {
        if (m_MenuToggle != null && m_MenuToggle.isOn && !m_Paused)
        {
            MenuOn();
        }
        else if (m_MenuToggle != null && !m_MenuToggle.isOn && m_Paused)
        {
            MenuOff();
        }
    }

    public void MenuOn()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        m_Paused = true;
    }


    public void MenuOff()
    {
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        m_Paused = false;
    }

    public void ExitAplication()
    {
        Application.Quit();
    }

#if !MOBILE_INPUT
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_MenuToggle.isOn = !m_MenuToggle.isOn;
            Cursor.visible = m_MenuToggle.isOn;
        }
    }
#endif
}
