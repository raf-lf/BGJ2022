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
        Sala01,
        Sala02,
        Cozinha,
        Corredor01,
        Corredor02,
        Banheiro,
        Sala03,
        Cozinha02
    }
    public RoomConfig[] roomConfig;
    public static RoomStateController roomStateController;
    public Room atualRoom;
    public int atualCamera;

    public void Awake()
    {
        if (roomStateController == null)
        {
            roomStateController = this;
        }
    }

    public void ChangeRoom(SwitchCameraColliderConfig newRoom)
    {
        atualRoom = newRoom.roomConfig.roomState;
        atualCamera = newRoom.roomConfig.vCamIndex;
        UpdateRoom?.Invoke();
    }

    public Room GetRoom()
    {
        return atualRoom;
    }

    public int GetRoomIndex()
    {
        int index = 0;

        for (int i = 0; i < roomConfig.Length; i++)
        {
            if(atualRoom == roomConfig[i].roomState)
            {
                index = i;
            }
        }
        return index;
    }
}
