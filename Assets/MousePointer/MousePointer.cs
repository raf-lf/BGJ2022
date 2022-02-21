using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class MousePointer : MonoBehaviour
{
    public GameObject aim;

    private MouseTarget target;
    public LayerMask interactionLayer;
    Vector3 hitPoint;

    private void Start()
    {
        hitPoint = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        CheckMouseRaycast();

        aim.transform.position = hitPoint;
    }

    public void CheckMouseRaycast()
    {
        if(Physics.Raycast(MouseWorldPosition(), out RaycastHit hitI))
        {
            hitPoint = hitI.point;
        }

        if (Physics.Raycast(MouseWorldPosition(), out RaycastHit hit, interactionLayer) && hit.collider.CompareTag("Interagivel"))
        {
            target = hit.collider.gameObject.GetComponent<MouseTarget>();

            if(target != null)
            {
                target.isOnMouseTarget = true;
                target.changeMaterial = true;
            }
        }
        else
        {
            if (target != null)
            {
                target.changeMaterial = true;
                target.isOnMouseTarget = false;
            }
            target = null;
        }
    }

    public Ray MouseWorldPosition()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(MouseWorldPosition());
    }
}