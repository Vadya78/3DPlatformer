using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorAI : MonoBehaviour
{
    public bool loaderGo;

	void Update ()
    {
        if(loaderGo)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Where is collision? " + collision.transform.name);
        if(collision.transform.tag != "Player")
        {
            loaderGo = false;
        }
    }
}
