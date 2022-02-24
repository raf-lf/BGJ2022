using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
    public enum TitleScreenState
    {
        Entry,
        WaitingInteraction,
        ShowingOptions,
        MainScreen,
        Options,
        Credit,
        Quit,
        EnteringInGame
    }
    public TitleScreenState titleState;
    public Animator anim;
   

    private void Awake()
    {
        if(anim == null)
            anim = GetComponent<Animator>();
    }

    private void Start()
    {
        ChangeTitleScreenState(TitleScreenState.Entry);
    }

    private void Update()
    {
        switch (titleState)
        {
            case TitleScreenState.Entry:
            case TitleScreenState.WaitingInteraction:
                if (Input.anyKeyDown)
                {
                    ChangeTitleScreenState(TitleScreenState.ShowingOptions);
                }
                break;
            default:
                break;
        }
    }

    public void ChangeTitleScreenState(TitleScreenState newState)
    {
        if (newState == titleState)
            return;

        titleState = newState;
        anim.Play(newState.ToString());
    }

    public void ChangeTitleScreenStateByString(string newState)
    {
        if (newState == titleState.ToString())
            return;

        TitleScreenState state;

        switch (newState)
        {
            case "Entry":
                state = TitleScreenState.Entry;
                break;

            case "WaitingInteraction":
                state = TitleScreenState.WaitingInteraction;
                break;

            case "ShowingOptions":
                state = TitleScreenState.ShowingOptions;
                break;

            case "MainScreen":
                state = TitleScreenState.MainScreen;
                break;

            case "Options":
                state = TitleScreenState.Options;
                break;

            case "Credit":
                state = TitleScreenState.Credit;
                break;

            case "Quit":
                state = TitleScreenState.Quit;
                break;

            default:
            case "EnteringInGame":
                state = TitleScreenState.EnteringInGame;
                break;
        }

        titleState = state;
    }

    public void PlayAnimation(string animName)
    {
        anim.Play(animName);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
