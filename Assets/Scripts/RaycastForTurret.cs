using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForTurret : MonoBehaviour
{
    public Transform character;
    private Searchlight searchlight;
    public GameObject bullet;
    public float bulletSpeed;
    private int layerMask;

    private void Start()
    {
        searchlight = GetComponent<Searchlight>();

        //Raycats all layers except 8 layer
        layerMask = 1 << 8;
        layerMask = ~layerMask;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Ray ray = new Ray(transform.position, (other.transform.position - transform.position).normalized);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if(hit.transform.tag == "Player" && searchlight.charDetected != true)
                {
                    searchlight.charDetected = true;
                    InvokeRepeating("CreateBullet", 1, 1);
                }
                else
                {
                    if(hit.transform.tag != "Player" && searchlight.charDetected == true)
                    {
                        StartCoroutine("StopFire");
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && searchlight.charDetected == true)
        {
            Debug.Log("Trigger out");
            StartCoroutine("StopFire");
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

    IEnumerator StopFire()
    {
        yield return new WaitForSecondsRealtime(2f);
        CancelInvoke();
        searchlight.charDetected = false;
    }
}
