using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    private Renderer rend;
    private Color actualColor;
    [SerializeField]
    private Animator shaderAnim;
    [SerializeField]
    private Animator objectAnim;
    public bool isOnMouseTarget;
    public bool changeMaterial;

    public bool interactable = true;

    protected virtual void Awake()
    {
        //rend = GetComponent<Renderer>();
    }

    private void Start()
    {
        //actualColor = rend.material.color;
        isOnMouseTarget = false;
        changeMaterial = false;
    }

    protected virtual void Update()
    {
        if (changeMaterial)
        {
            if (isOnMouseTarget && interactable)
                OverMouse();
            else
                LeftMouse();
        }
    }

    public virtual void Interact()
    {

    }

    private void CheckClick()
    {
        if (Input.GetMouseButton(0) && isOnMouseTarget && interactable)
            Interact();
    }

    private void OverMouse()
    {
        shaderAnim.SetBool("mouseOver", true);
        //rend.material.color = Color.red;
        changeMaterial = false;
    }

    private void LeftMouse()
    {
        shaderAnim.SetBool("mouseOver", false);
        //rend.material.color = actualColor;
        changeMaterial = false;
    }
}
