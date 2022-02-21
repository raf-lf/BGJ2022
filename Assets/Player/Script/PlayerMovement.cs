using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    Vector3 moveDir;

    private void Start()
    {
        moveDir = Vector3.zero;
    }

    private void Update()
    {
        DoMovement();
    }

    public void DoMovement()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.z = Input.GetAxisRaw("Vertical");
        moveDir = moveDir.normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }
}
