using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForAi : MonoBehaviour
{
    public Transform character;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RaycastHit hit;
            //Не забыть учесть рост персонажа
            Ray ray = new Ray(transform.position, (character.position - transform.position).normalized);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if(hit.transform.tag == "Player")
                {
                    Debug.Log("Well done");
                }
            }
        }
    }
}
