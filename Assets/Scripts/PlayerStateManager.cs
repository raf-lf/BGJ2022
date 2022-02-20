using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerComponents playerComponents;
    public States.PlayerStates playerState => States.playerState;
    public GameObject[] stateObjects;
    public string atualState; 

    private void Start()
    {
        ChangePlayerState(States.PlayerStates.Idle);
    }

    private void Update()
    {
        atualState = States.playerState.ToString();
    }

    public void ChangePlayerState(States.PlayerStates newState)
    {
        switch (newState)
        {
            default:
            case States.PlayerStates.Idle:
                Debug.Log("Atual State: " + playerState + " / New State: " + newState);
                ChangeScript(0);
                break;

            case States.PlayerStates.Walk:
                Debug.Log("Atual State: " + playerState + " / New State: " + newState);
                ChangeScript(1);
                break;
        }

        States.ChangePlayerState(newState);
    }

    public void ChangeScript(int indice)
    {
        for (int i = 0; i < stateObjects.Length; i++)
        {
            if(i == indice)
            {
                stateObjects[i].SetActive(true);
            }
            else
            {
                stateObjects[i].SetActive(false);
            }

        }
    }
}