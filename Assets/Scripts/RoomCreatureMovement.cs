using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreatureMovement : MonoBehaviour
{
    public string roomName;
    public List<RoomCreatureMovement> adjacentRooms;
    public List<Transform> spot;

    public Transform GetRandomSpot()
    {
        return spot[Random.Range(0, spot.Count)];
    }
}
