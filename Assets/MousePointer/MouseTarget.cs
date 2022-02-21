using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    private Renderer rend;
    private Color actualColor;
    public bool isOnMouseTarget;
    public bool changeMaterial;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Start()
    {
        actualColor = rend.material.color;
        isOnMouseTarget = false;
        changeMaterial = false;
    }

    private void Update()
    {
        if (changeMaterial)
        {
            if (isOnMouseTarget)
            {
                OverMouse();
            }
            else
            {
                LeftMouse();
            }
        }
    }

    private void OverMouse()
    {
        rend.material.color = Color.red;
        changeMaterial = false;
    }

    private void LeftMouse()
    {
        rend.material.color = actualColor;
        changeMaterial = false;
    }
}
