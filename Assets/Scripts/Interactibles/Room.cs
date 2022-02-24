using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Candles & Windows")]
    public List<Candle> candlesInRoom = new List<Candle>();
    public List<Window> windowsInRoom = new List<Window>();

    private bool windowOpen;

    [Header("Hints")]
    [TextArea(2, 4)]
    public string roomStarterHint;
    [TextArea(2, 4)]
    public string[] roomHint = new string[0];

    [HideInInspector]
    public List<SearchableSpot> searchablesInRoom = new List<SearchableSpot>();
    private void Awake()
    {
        candlesInRoom.AddRange(GetComponentsInChildren<Candle>());
        windowsInRoom.AddRange(GetComponentsInChildren<Window>());
    }
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

    private void Update()
    {

        foreach (var item in windowsInRoom)
        {
            if (item.isOpen)
            {
                windowOpen = true;
                break;
            }
            else
                windowOpen = false;

        }

        if (windowOpen)
        {
            foreach (var item in candlesInRoom)
            {
                item.DecayCandle();
            }
        }

    }
}
