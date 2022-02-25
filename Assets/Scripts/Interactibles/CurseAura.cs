using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseAura : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SanityManager.sanityScript.curse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SanityManager.sanityScript.curse = false;
        }
    }

}
