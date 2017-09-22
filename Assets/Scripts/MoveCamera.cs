using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform characterPosition;
    private Transform cameraPosition;

	void Start ()
    {
        cameraPosition = GetComponent<Transform>();
	}
	
	void Update () 
    {
        cameraPosition.transform.position = new Vector3(cameraPosition.position.x, cameraPosition.position.y, characterPosition.position.z) ;
	}
}
