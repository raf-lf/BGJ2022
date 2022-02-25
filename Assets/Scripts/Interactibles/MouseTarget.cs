using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    [SerializeField]
    protected Animator shaderAnim;
    [SerializeField]
    protected Animator objectAnim;
    public bool isOnMouseTarget;
    public bool changeMaterial;

    public bool interactable = true;

    public GameObject item;

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
            {
                OverMouse();
                CheckClick();
            }
            else
                LeftMouse();
        }
    }

    public virtual void Interact()
    {
        //Debug.Log("Interacted with " + name);
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0) && isOnMouseTarget && interactable)
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
