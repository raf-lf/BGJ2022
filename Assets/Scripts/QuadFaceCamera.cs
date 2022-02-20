using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadFaceCamera : MonoBehaviour
{
    public Transform camTransform;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(camTransform);
    }

}
