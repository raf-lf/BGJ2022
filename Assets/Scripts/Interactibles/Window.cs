using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MouseTarget
{
    [Header("Window")]
    public bool isOpen;
    public bool locked;
    public float closedTime;
    public float closedTimeVariance;
    [SerializeField]
    private float timer;

    private void Start()
    {
        timer = closedTime + Random.Range(-closedTimeVariance, closedTimeVariance);
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
        timer = closedTime + Random.Range(-closedTimeVariance, closedTimeVariance);
        objectAnim.SetBool("open", false);
        interactable = false;

    }

    public void OpenWindow()
    {
        isOpen = true;
        objectAnim.SetBool("open", true);
        interactable = true;

    }

    protected override void Update()
    {
        base.Update();

        if(!locked)
        {
            if (timer <= 0)
            {
                OpenWindow();
            }
            else
                timer = Mathf.Clamp(timer - Time.deltaTime, 0, Mathf.Infinity);
        }
    }
}
