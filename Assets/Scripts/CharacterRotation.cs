using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    private float rightTurn = 0;
    private float leftTurn = 180;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        //Временный костыль
		if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, leftTurn, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, rightTurn, 0);
        }
	}
}
