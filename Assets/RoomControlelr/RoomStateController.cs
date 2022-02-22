using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStateController : MonoBehaviour
{
    public delegate void OnUpdateRoom();
    public static event OnUpdateRoom UpdateRoom;
    public enum Room
    {
        Quarto,
        Sala,
        Cozinha,
        Corredor,
        Banheiro
    }
    public RoomConfig[] roomConfig;
    public static RoomStateController roomStateController;
    public Room actualRoom;

    public void Awake()
    {
        if (roomStateController == null)
        {
            roomStateController = new RoomStateController();
            roomStateController.roomConfig = new RoomConfig[roomConfig.Length];

            for (int i = 0; i < roomConfig.Length; i++)
            {
                roomStateController.roomConfig[i] = roomConfig[i];
            }
        }
    }

    public void ChangeRoom(Room newRoom)
    {
        actualRoom = newRoom;
        UpdateRoom?.Invoke();
    }

    public Room GetRoom()
    {
        return actualRoom;
    }

    public int GetRoomIndex()
    {
        int index = 0;

        for (int i = 0; i < roomConfig.Length; i++)
        {
            if(actualRoom == roomConfig[i].roomState)
            {
                index = i;
            }
        }
        return index;
    }
}
