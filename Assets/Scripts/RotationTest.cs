using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public GameObject rotateTarget;
    public float rotateSpeed;
    public Vector3 rotationChange;

    private void Update()
    {
        rotationChange = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
            rotationChange = new Vector3(rotateSpeed, 0, 0);
        

        if (Input.GetKey(KeyCode.W))
            rotationChange = new Vector3(0, rotateSpeed, 0);

        if (Input.GetKey(KeyCode.E))
            rotationChange = new Vector3(0, 0, rotateSpeed);

        rotateTarget.transform.Rotate(rotationChange);
    }
}
