using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActivationLoader : MonoBehaviour
{
    private Text helpTitle;
    private MotorAI loaderMotor;

    private void Awake()
    {
        helpTitle = GetComponentInChildren<Text>();
        loaderMotor = GetComponentInParent<MotorAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && loaderMotor.loaderGo != true)
        {
            helpTitle.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                loaderMotor.loaderGo = true;
                helpTitle.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            helpTitle.enabled = false;
        }
    }
}
