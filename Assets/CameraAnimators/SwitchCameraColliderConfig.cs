using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraColliderConfig : MonoBehaviour
{
    public int vCamNumer = 0;
    private SwitchCameras controller;

    private void Awake()
    {
        controller = GetComponentInParent<SwitchCameras>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller.SwitchCamera(vCamNumer);
        }
    }
}
