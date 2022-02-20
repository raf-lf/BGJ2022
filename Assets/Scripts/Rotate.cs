using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject pointOfRotation;
    public float rotationSpeed;
    public float counter;

    private void Start()
    {
        counter = 0;
    }

    private void Update()
    {
        if (counter < 180)
            counter += Time.deltaTime * 10 * rotationSpeed;
        else
            counter = 0;

        transform.Rotate(transform.position, Mathf.Sin(Time.time * rotationSpeed));
    }
}
