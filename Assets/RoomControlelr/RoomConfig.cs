using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "Room_", menuName = "Create Scriptable Objects/Create Room")]
public class RoomConfig : ScriptableObject
{
    public string roomName;
    [TextArea(0, 20)] public string roomDescription;

    public RoomStateController.Room roomState;
    public int vCamIndex;

    public GameObject[] itemSpot;
}
