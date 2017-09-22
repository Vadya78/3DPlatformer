using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
	void Start () {
		
	}
	
	void Update ()
    {
        transform.Rotate(Vector3.up * 90 * Time.deltaTime);
	}

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

        }
    }*/
}
