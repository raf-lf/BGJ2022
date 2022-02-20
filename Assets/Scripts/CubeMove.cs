using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CubeMove : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    public CinemachineVirtualCamera vCamera;
    public float cameraSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0, 0);

        rb.AddForce(movement, ForceMode.Impulse);
    }

}
