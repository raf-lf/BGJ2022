using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    [Header("Monster Spawn Configuration")]
    [Range(0.1f, 2f)]public float monsterSpawnMultiplier;

    [Header("Monster Spawn Atributes")]
    public List<RoomCreatures> roomCreature;
    public List<GameObject> monster;

    private void OnEnable()
    {
        RoomStateController.UpdateRoom += ShowMonsters;
    }

    private void OnDisable()
    {
        RoomStateController.UpdateRoom -= ShowMonsters;
    }

    public void GetRoomMonsters()
    {
        int usedRoom = 0;

        if(monster.Count > 0)
            monster.Clear();

        RoomStateController.Room atualRoom = RoomStateController.roomStateController.GetRoom();

        for (int i = 0; i < roomCreature.Count; i++)
        {
            if(atualRoom == roomCreature[i].roomState)
            {
                usedRoom = i;
            }
        }

        for (int i = 0; i < roomCreature[usedRoom].monster.Count; i++)
        {
            monster.Add(roomCreature[usedRoom].monster[i]);
        }
    }

    public void ShowMonsters()
    {
        UpdateRoomCreature();
        GetRoomMonsters();

        float howManyMonstersWillSpawn = (SanityManager.sanityScript.SanityMax - SanityManager.sanityScript.sanity - SanityManager.sanityScript.SanityMax/10*9) * monsterSpawnMultiplier;
        int spawnCounter = 0;

        while(spawnCounter < howManyMonstersWillSpawn)
        {
            for (int i = 0; i < monster.Count; i++)
            {
                if (Random.Range(0, 100) < 50)
                {
                    monster[i].SetActive(true);
                    spawnCounter += 1;
                }
                else
                {
                    monster[i].SetActive(false);
                }
            }
        }
    }

    [ContextMenu("Update Rooms Creature")]
    public void UpdateRoomCreature()
    {
        if(roomCreature.Count > 0)
            roomCreature.Clear();

        foreach(RoomCreatures g in gameObject.GetComponentsInChildren<RoomCreatures>())
        {
            roomCreature.Add(g);
        }
    }

    public void UpdateAll()
    {
        UpdateRoomCreature();
        foreach(RoomCreatures r in roomCreature)
        {
            r.UpdateMonsters();
        }
    }
}