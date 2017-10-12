using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForTurret : MonoBehaviour
{
    public Transform character;
    private Searchlight searchlight;
    public GameObject bullet;
    public float bulletSpeed;

    private void Start()
    {
        searchlight = GetComponent<Searchlight>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("ColliderEnter");
            Ray ray = new Ray(transform.position, (other.transform.position - transform.position).normalized);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Player" && searchlight.charDetected != true)
                {
                    Debug.Log("RaycastDetected");
                    searchlight.charDetected = true;
                    InvokeRepeating("CreateBullet", 1, 1);
                }
                else
                {
                    if(hit.transform.tag != "Player" && searchlight.charDetected == true)
                    {
                        Debug.Log("hit name " + hit.transform.name);
                        searchlight.charDetected = false;
                        CancelInvoke();
                    }
                }
            }
        }
    }

    private void CreateBullet()
    {
        Rigidbody inst = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
        inst.velocity = (transform.forward * bulletSpeed);

        //Ray ray = new Ray(transform.position, (character.transform.position - transform.position).normalized);
        //RaycastHit hit;

        /*if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag != "Player")
            {
                searchlight.charDetected = false;
                CancelInvoke();
            }
        }*/
    }
}
