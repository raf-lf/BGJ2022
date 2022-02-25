using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProximityCheck : MonoBehaviour
{
    public ParticleSystem ps;
    private ParticleSystem.EmissionModule psEmission;
    private MouseTarget targetToLock;

    private void Awake()
    {
        targetToLock = GetComponentInParent<MouseTarget>();
        psEmission = ps.emission;
        //psShape.radius = GetComponent<SphereCollider>().radius;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            targetToLock.interactable = true;
            psEmission.enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetToLock.interactable = false;
            psEmission.enabled = false;
        }

    }

}
