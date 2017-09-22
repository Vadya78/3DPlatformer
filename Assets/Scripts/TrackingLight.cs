using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingLight : MonoBehaviour
{
    public Transform target;

	void Start () {
		
	}
	
	void Update ()
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
	}
}
