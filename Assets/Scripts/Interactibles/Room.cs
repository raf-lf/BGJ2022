using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Candles & Windows")]
    public Candle candleInRoom;
    public List<Window> windowsInRoom = new List<Window>();

    [Header("Hints")]
    [TextArea(2, 4)]
    public string roomStarterHint;
    [TextArea(2, 4)]
    public string[] roomHint = new string[0];

    [HideInInspector]
    public List<SearchableSpot> searchablesInRoom = new List<SearchableSpot>();

    public void UpdateSpots()
    {
        searchablesInRoom.AddRange(GetComponentsInChildren<SearchableSpot>());
    }

    public void RoomExit()
    {
        foreach (SearchableSpot obj in searchablesInRoom)
        {
            obj.ResetObject();
        }
    }
    
    public string GetStarterHint()
    {
        return roomStarterHint;
    }

    public string GetRoomHint()
    {
        return roomHint[Random.Range(0, roomHint.Length)];
    }
}
