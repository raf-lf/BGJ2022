using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MouseTarget
{
    [Header("Window")]
    public bool isOpen;
    public float lockedTimeAfterClosing = 20;
    public float lockedTimer;

    public PlaySfx sfxOpen;
    public PlaySfx sfxClose;

    [SerializeField]
    //private float timer;

    private void Start()
    {
        //timer = closedTime + Random.Range(-closedTimeVariance, closedTimeVariance);
        objectAnim.SetBool("open", false);
        interactable = false;
    }

    public override void Interact()
    {
        base.Interact();
        CloseWindow();

    }

    public void CloseWindow()
    {
        isOpen = false;
        lockedTimer = lockedTimeAfterClosing;
        objectAnim.SetBool("open", false);
        interactable = false;
        sfxClose.PlayInspectorSfx();

    }

    public void OpenWindow()
    {
        isOpen = true;
        objectAnim.SetBool("open", true);
        interactable = true;
        sfxOpen.PlayInspectorSfx();

    }

    protected override void Update()
    {
        base.Update();

        if(lockedTimer > 0)
            lockedTimer = Mathf.Clamp(lockedTimer - Time.deltaTime, 0, Mathf.Infinity);
    }
}
