using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class MousePointer : MonoBehaviour
{
    private MouseTarget target;
    public LayerMask interactionLayer;

    private void Update()
    {
        CheckMouseRaycast();

        if(Input.GetMouseButtonDown(0) && target != null && EventSystem.current.IsPointerOverGameObject())
        {
            CheckTargetItem();
        }
    }

    public void CheckTargetItem()
    {
        string debug = "";
        if(target.item == null)
        {
            // Bunitezas do farinha (~'u')~ // Animação puff
            debug += "Nada \n";
        }
        else
        {
            // Animar overlay Item;

            // Bunitezas do farinha (~'u')~ //
            debug += "Encontrou item \n";
            QuestSystem.qS.NextQuest();
        }

        Debug.Log(debug);
    }

    public void CheckMouseRaycast()
    {
        bool hitou = Physics.Raycast(MouseWorldPosition(), out RaycastHit hit, interactionLayer);

        if (hitou && hit.collider.CompareTag("Interagivel"))
        {
            if (target != null)
            {
                target.changeMaterial = true;
                target.isOnMouseTarget = false;
            }

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