using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public MouseTarget[] spot;
    public ItemObject[] item;

    [ContextMenu("SortearItems")]
    public void SortQuestLine()
    {
        for (int i = 0; i < item.Length; i++)
        {
            item[i].questObjective = i;
            spot[Random.Range(0, spot.Length)].item = item[i].gameObject;
        }
    }
}