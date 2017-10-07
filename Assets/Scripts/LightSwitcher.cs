using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    Light lampLight;

	void Start ()
    {
        lampLight = GetComponentInChildren<Light>();
        StartCoroutine(LightSwitching());
    }

    IEnumerator LightSwitching()
    {
        for(;;)
        {
            if (Time.timeScale != 0)
            {
                lampLight.enabled = !lampLight.enabled;
                yield return new WaitForSecondsRealtime(3);
            }
            else break;
        }
    }


}
