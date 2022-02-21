using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    Vector3 moveInput;

    private void Start()
    {
        moveInput = Vector3.zero;
    }

    private void Update()
    {
        DoMovement();
    }

    public void DoMovement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.z = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;

        var cam = Camera.main;
        var foward = cam.transform.forward;
        var right = cam.transform.right;

        foward.y = 0f;
        right.y = 0f;
        foward.Normalize();
        right.Normalize();

        var desiredMoveDirection = (foward * moveInput.z + right * moveInput.x).normalized;

        if (moveInput.magnitude >= 0.1f)
        {
            controller.Move(desiredMoveDirection * speed * Time.deltaTime);
        }
    }
}
