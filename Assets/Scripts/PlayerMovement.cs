using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public CharacterController controller;
    public float speed;
    Vector3 moveInput;
    private Animator anim;
    public ParticleSystem stepParticles;
    public PlaySfx stepSfx;

    [Header("Room")]
    public List<SwitchCameraColliderConfig> roomCollider;

    private void Start()
    {
        moveInput = Vector3.zero;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        DoMovement();
        CheckRoom();
    }

    public void Step()
    {
        stepSfx.PlayInspectorSfx();
        stepParticles.Play();
    }

    public void CheckRoom()
    {
        if(roomCollider[roomCollider.Count-1].roomConfig.roomState != RoomStateController.roomStateController.GetRoom())
        {
            RoomStateController.roomStateController.ChangeRoom(roomCollider[roomCollider.Count-1].roomConfig.roomState);
        }
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
            anim.SetBool("moving", true);
            controller.Move(desiredMoveDirection * speed * Time.deltaTime);
        }
        else
            anim.SetBool("moving", false);
    }
}