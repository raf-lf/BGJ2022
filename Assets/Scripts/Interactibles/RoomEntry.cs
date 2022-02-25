using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomEntry : MonoBehaviour
{
    private Room connectedRoom;

    private void Awake()
    {
        connectedRoom = GetComponentInParent<Room>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            connectedRoom.RoomEntry();
    }

}
