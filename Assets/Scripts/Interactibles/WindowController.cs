using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [Header("Configurations")]
    public float closedTime;
    public float closedTimeVariance;
    [SerializeField]
    private float timer;
    public List<Window> windows;

    private void Start()
    {
        UpdateWindowList();
        timer = closedTime + Random.Range(-closedTimeVariance, closedTimeVariance);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            Window openingWIndow = GetRandomValidWindow();

            if(openingWIndow != null)
                openingWIndow.OpenWindow();

            timer = closedTime + Random.Range(-closedTimeVariance, closedTimeVariance);
        }
        else
            timer = Mathf.Clamp(timer - Time.deltaTime, 0, Mathf.Infinity);
    }

    public Window GetRandomValidWindow()
    {
        List<Window> elegibleWindows = new List<Window>();

        for (int i = 0; i < windows.Count; i++)
        {
            if (!windows[i].isOpen && windows[i].lockedTimer <=0)
            {
                elegibleWindows.Add(windows[i]);
            }
        }

        if (elegibleWindows.Count > 0)
            return elegibleWindows[Random.Range(0, elegibleWindows.Count)];
        else return null;
    }

    [ContextMenu("Update Windows")]
    public void UpdateWindowList()
    {
        windows.Clear();

        foreach (var item in GameManager.rooms)
        {
            windows.AddRange(item.GetComponentsInChildren<Window>());
        }

    }
}