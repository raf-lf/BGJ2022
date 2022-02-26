using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [Header("Configurations")]
    public float closedTime;
    public float closedTimeVariance;
    private float timer;

    [Header("Atributos")]
    public List<Window> windows;
    private Window windowToOpen;

    private void Start()
    {
        timer = closedTime + Random.Range(-closedTimeVariance, closedTimeVariance);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            GetRandomWindowToOpen();
            windowToOpen.OpenWindow();
        }
        else
            timer = Mathf.Clamp(timer - Time.deltaTime, 0, Mathf.Infinity);
    }

    public void GetRandomWindowToOpen()
    {
        List<Window> elegibleWindows = new List<Window>();

        for (int i = 0; i < windows.Count; i++)
        {
            if (!windows[i].isOpen)
            {
                elegibleWindows.Add(windows[i]);
            }
        }

        windowToOpen = elegibleWindows[Random.Range(0, elegibleWindows.Count)];
    }

    [ContextMenu("Update Windows")]
    public void UpdateWindowList()
    {
        windows.Clear();

        foreach(Window w in gameObject.GetComponentsInChildren<Window>())
        {
            windows.Add(w);
        }
    }
}