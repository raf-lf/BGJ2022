using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkScript : MonoBehaviour
{
    public PlayerStateManager playerStateManager;
    [Range(1, 60)] public float playerSpeed;
    private Vector2 moveForce;

    public string animNameLookUp, animNameLookRight, animNameLookDown, animNameLookLeft;

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        moveForce = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime);

        playerStateManager.playerComponents.rb.AddForce(moveForce, ForceMode2D.Impulse);
    }
}
