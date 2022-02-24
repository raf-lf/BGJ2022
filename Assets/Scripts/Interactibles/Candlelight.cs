using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candlelight : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SanityManager.lightLevel++;
            Debug.Log("Light level: " + SanityManager.lightLevel);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SanityManager.lightLevel--;
            Debug.Log("Light level: " + SanityManager.lightLevel);
        }
    }

}
