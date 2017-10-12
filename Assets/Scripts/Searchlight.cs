using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchlight : MonoBehaviour
{
    private float t = 0.0f;
    public float maxT = 0.4f;
    public float minRotAngle = 5;
    public float maxRotAngle = 175;
    public float rotSpeed = 0.1f;
    public bool charDetected;
    public Transform character;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(Time.timeScale != 0)
        {
            if(!charDetected)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, maxRotAngle, 0), t);
                t += rotSpeed;
                if (t > maxT)
                {
                    float temp = maxRotAngle;
                    maxRotAngle = minRotAngle;
                    minRotAngle = temp;
                    t = 0.0f;
                }
            }
            else
            {
                Vector3 relativePos = character.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                transform.rotation = rotation;
                //inst.AddForce(transform.forward * bulletSpeed);
            }
        }
	}
}
