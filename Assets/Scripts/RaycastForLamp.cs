using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class RaycastForLamp : MonoBehaviour
{
    private AudioSource alarm;
    private bool charDetected;
    private LightSwitcher lightSwitcher;

    private void Awake()
    {
        alarm = GetComponent<AudioSource>();
        lightSwitcher = FindObjectOfType<LightSwitcher>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Ray ray = new Ray(transform.position, (other.transform.position - transform.position).normalized);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player" && charDetected != true)
                {
                    Debug.Log("Detected");
                    alarm.Play();
                    lightSwitcher.CharacterDetected();
                    charDetected = true;
                }
            }
        }
    }
}
