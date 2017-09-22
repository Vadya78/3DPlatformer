using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public AudioMixer mixer;
    public static AudioManager instance;
    public AudioSetting[] audioSettings;

    private enum AudioGroups { Music, SFX };

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        instance = GetComponent<AudioManager>();
    }

    void Start()
    {
        for (int i = 0; i < audioSettings.Length; i++)
        {
            audioSettings[i].Initialize();
        }
    }

    public void SetMusicVolume(float value)
    {
        audioSettings[(int)AudioGroups.Music].SetExposedParam(value);
    }

    public void SetSFXVolume(float value)
    {
        audioSettings[(int)AudioGroups.SFX].SetExposedParam(value);
    }

    /*public void SnapshotStarting()
    {
        startingSnapshot.TransitionTo(.5f);
    }

    public void SnapshotMusic()
    {
        musicOffSnapshot.TransitionTo(.5f);
    }*/
}

[System.Serializable]
public class AudioSetting
{
    public Slider slider;
    public Toggle selector;
    public string exposedParam;

    public void Initialize()
    {
        slider.value = PlayerPrefs.GetFloat(exposedParam);
    }

    public void SetExposedParam(float value)
    {
        if (value <= slider.minValue)
        {
            selector.isOn = true;
        }
        else
        {
            selector.isOn = false;
        }

        AudioManager.instance.mixer.SetFloat(exposedParam, value);
        PlayerPrefs.SetFloat(exposedParam, value);
    }
}

