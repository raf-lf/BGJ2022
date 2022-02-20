using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerStateManager playerStateManager;

    void Update()
    {
        switch (playerStateManager.playerState)
        {
            case States.PlayerStates.Idle:
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.1f)
                {
                    playerStateManager.ChangePlayerState(States.PlayerStates.Walk);
                }
                break;

            case States.PlayerStates.Walk:
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) <= 0.1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) <= 0.1f)
                {
                    playerStateManager.ChangePlayerState(States.PlayerStates.Idle);
                }
                break;
        }
    }
}