using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    [Header("Monster Spawn Configuration")]
    public float monsterSpawnMultiplier;

    [Header("Monster Spawn Atributes")]
    public List<GameObject> monster;
    /*
    private void OnEnable()
    {
        Room.OnEntry += ShowMonsters;
        Room.OnExit += ShowMonsters;
    }

    private void OnDisable()
    {
        Room.OnEntry -= ShowMonsters;
        Room.OnExit -= ShowMonsters;
    }
    */

    public void ShowMonsters()
    {
        float howManyMonstersWillSpawn = (SanityManager.sanityScript.SanityMax - SanityManager.sanityScript.sanity) * monsterSpawnMultiplier;
        int spawnCounter = 0;

        for (int i = 0; i < monster.Count; i++)
        {
            if(spawnCounter < howManyMonstersWillSpawn)
            {
                if(Random.Range(0, 100) < 50)
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

    [ContextMenu("Update Monsters")]
    public void UpdateMonsters()
    {
        monster.Clear();

        foreach(GameObject g in gameObject.GetComponentsInChildren<GameObject>())
        {
            monster.Add(g);
        }
    }
}