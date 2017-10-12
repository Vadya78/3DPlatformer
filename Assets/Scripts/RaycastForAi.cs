using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class RaycastForAi : MonoBehaviour
{
    public Transform character;
    private NavMeshAgent navMeshAgent;
    private bool characterDetected;
    private float speedAfteCharacterDetecred = 3.5f;

    private void Start()
    {
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
    }

    private void Update()
    {
        if(characterDetected)
        {
            navMeshAgent.SetDestination(character.position);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            RaycastHit hit;
            //Не забыть учесть рост персонажа
            Ray ray = new Ray(transform.position, (character.position - transform.position).normalized);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Player" && characterDetected != true)
                {
                    characterDetected = true;
                    navMeshAgent.speed = speedAfteCharacterDetecred;
                    Debug.Log("Detected");
                }
            }
        }
    }
}
