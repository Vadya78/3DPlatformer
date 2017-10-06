using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingCharacter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You are caught"); //Pause menu is future
        }
    }
}
