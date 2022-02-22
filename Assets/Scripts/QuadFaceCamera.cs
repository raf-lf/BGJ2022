using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadFaceCamera : MonoBehaviour
{
    private  Transform camTransform;

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(camTransform);
    }

}
