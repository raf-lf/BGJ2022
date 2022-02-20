using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class States
{
    public enum PlayerStates
    {
        Idle,
        Walk
    }
    public static PlayerStates playerState;

    public static void ChangePlayerState (PlayerStates newState)
    {
        playerState = newState;
    }
}
