using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomToCreatureMovementManager : MonoBehaviour
{
    public List<RoomCreatureMovement> room;

    public RoomCreatureMovement GetRandomRoom()
    {
        return room[Random.Range(0, room.Count)];
    }

    public RoomCreatureMovement GetRandomRoomBetweenAdjacents(string atualRoomName)
    {
        RoomCreatureMovement atualRoom = new RoomCreatureMovement();

        for (int i = 0; i < room.Count; i++)
        {
            if(atualRoomName == room[i].roomName)
            {
                atualRoom = room[i];
                break;
            }
        }

        return atualRoom.adjacentRooms[Random.Range(0, atualRoom.adjacentRooms.Count)];
    }

    [ContextMenu("Update Rooms")]
    public void UpdateRooms()
    {
        room.Clear();

        foreach(RoomCreatureMovement r in gameObject.GetComponentsInChildren<RoomCreatureMovement>())
        {
            room.Add(r);
        }
    }
}
