using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
    {
        PlayerPrefs.SetInt("Player Detected", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
