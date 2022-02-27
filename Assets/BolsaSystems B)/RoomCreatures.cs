using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreatures : MonoBehaviour
{
    public List<GameObject> monster;
    public RoomStateController.Room roomState;

    [ContextMenu("Update Mosnters")]
    public void UpdateMonsters()
    {
        monster.Clear();

        foreach(GameObject g in GetComponentsInChildren<GameObject>())
        {
            if (g.CompareTag("Monster"))
            {
                monster.Add(g);
            }
        }
    }
}
