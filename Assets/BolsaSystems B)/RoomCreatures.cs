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
        if(monster.Count>0) monster.Clear();

        GameObject[] samuel = gameObject.GetComponentsInChildren<GameObject>();

        foreach (GameObject g in samuel)
        {
            if (g.CompareTag("Monsters"))
            {
                monster.Add(g);
            }
        }
    }
}
