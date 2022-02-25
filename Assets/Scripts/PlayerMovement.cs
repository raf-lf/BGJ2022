using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public static bool PlayerControls = true;
    public CharacterController controller;
    public float speed;
    Vector3 moveInput;
    [HideInInspector]
    public Animator anim;
    public ParticleSystem stepParticles;
    public PlaySfx stepSfx;

    [Header("Room")]
    public List<SwitchCameraColliderConfig> roomCollider;

    [Header("Components")]
    public static GameObject Player;
    public GameObject PlayerRenderer;

    private void Awake()
    {
        Player = gameObject;
    }

    private void Start()
    {
        moveInput = Vector3.zero;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        DoMovement();
    }

    public void Step()
    {
        stepSfx.PlayInspectorSfx();
        stepParticles.Play();
    }

    public void DoMovement()
    {
        if (PlayerControls)
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
        else
            anim.SetBool("moving", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RoomCollider")) // estou saindo de um colisor de uma área
        {
            SwitchCameraColliderConfig colliderConfig = other.GetComponent<SwitchCameraColliderConfig>();

            if (RoomStateController.roomStateController.atualCamera != colliderConfig.roomConfig.vCamIndex) // o colisor do qual estou saindo é de outro estado diferente do que eu estou.
            {
                RoomStateController.roomStateController.ChangeRoom(colliderConfig); // mudo a câmera para o colisor que acabei de sair
            }
        }
    }
}