using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraColliderConfig : MonoBehaviour
{
    public RoomConfig roomConfig;
    bool isInThisRoom;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (roomConfig.roomState != RoomStateController.roomStateController.GetRoom() && !isInThisRoom)
            {
                isInThisRoom = true;
                collision.GetComponent<PlayerMovement>().roomCollider.Add(this);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (roomConfig.roomState == RoomStateController.roomStateController.GetRoom())
            {
                var playerColliders = collision.GetComponent<PlayerMovement>().roomCollider;

                for (int i = 0; i < playerColliders.Count; i++)
                {
                    if (playerColliders[i].roomConfig == roomConfig)
                    {
                        collision.GetComponent<PlayerMovement>().roomCollider.Remove(collision.GetComponent<PlayerMovement>().roomCollider[i]);
                    }
                }

                isInThisRoom = false;
            }
        }
    }
}
