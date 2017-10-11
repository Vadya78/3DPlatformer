using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] targets;
    private int countOfTargets;
    private int i = 0;

	void Start ()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        countOfTargets = targets.Length;
        navMeshAgent.SetDestination(targets[i].position);
	}

	void Update ()
    {
        if (!navMeshAgent.pathPending)
        {
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0)
                {
                    if(i < countOfTargets - 1)
                    {
                        i++;
                        navMeshAgent.SetDestination(targets[i].position);
                    }
                    else
                    {
                        i = 0;
                        navMeshAgent.SetDestination(targets[i].position);
                    }
                    Debug.Log("Stopped");
                }
            }
        }


		/*if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }*/
	}
}
