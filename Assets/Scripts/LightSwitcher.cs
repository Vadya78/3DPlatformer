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
            lampLight.enabled = !lampLight.enabled;
            yield return new WaitForSecondsRealtime(3);
        }
    }


}
