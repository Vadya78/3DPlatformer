using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform characterPosition;
    public float cameraHeight = 2.5f;
    private Transform cameraPosition;

    void Start ()
    {
        cameraPosition = GetComponent<Transform>();
	}
	
	void Update () 
    {
        cameraPosition.transform.position = new Vector3(cameraPosition.position.x, characterPosition.position.y + cameraHeight, characterPosition.position.z) ;
	}
}
