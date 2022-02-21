using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Transform cam;
    private Animator anim;
    public float speed = 6f;


    private void Awake()
    {
        controller = GetComponentInChildren<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        cam = Camera.main.transform;
    }
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            /*
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref lerpVelocity, lerp);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), lerp);
            */

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if(anim != null)
                anim.SetBool("move", true);
        }
        else
        {
            if (anim != null)
                anim.SetBool("move", false);
        }

    }

}
