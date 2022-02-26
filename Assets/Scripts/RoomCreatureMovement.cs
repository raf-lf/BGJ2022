using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreatureMovement : MonoBehaviour
{
    public string roomName;
    public List<RoomCreatureMovement> adjacentRooms;
    public List<Transform> spot;

    private void Start()
    {
        UpdateSpots();
    }

    public Transform GetRandomSpot()
    {
        return spot[Random.Range(0, spot.Count)];
    }

    [ContextMenu("Update Spots")]
    public void UpdateSpots()
    {
        spot.Clear();

        Transform[] childrensTransform = GetComponentsInChildren<Transform>();

        foreach(Transform child in childrensTransform)
        {
            spot.Add(child);
        }
    }
}
