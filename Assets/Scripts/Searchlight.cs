using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchlight : MonoBehaviour
{
    private float t = 0.0f;
    public float maxT = 0.12f;
    public float minRotAngle = 5;
    public float maxRotAngle = 175;
    public float rotSpeed = 0.1f;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, maxRotAngle, 0), t);
        t += rotSpeed;
        if(t > maxT)
        {
            float temp = maxRotAngle;
            maxRotAngle = minRotAngle;
            minRotAngle = temp;
            t = 0.0f;
        }
	}

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }
    }*/
}
