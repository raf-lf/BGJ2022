using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSystem : MonoBehaviour
{
    public TMP_Text display;
    public string[] objectives;
    private int questState;
    public static QuestSystem qS;

    private void Awake()
    {
        if(qS == null)
        {
            qS = new QuestSystem();
        }
    }

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        display.text = objectives[questState];
    }

    public void NextQuest()
    {
        if(questState + 1 >= objectives.Length)
        {
            Debug.Log("Acabou as quests");
            return;
        }

        questState += 1;
        UpdateText();
    }

    public void PreviousQuest()
    {
        if (questState - 1 <= 0)
        {
            Debug.Log("Você já está na primeira quest");
            return;
        }

        questState -= 1;
        UpdateText();
    }

    public void ResetQuest()
    {
        questState = 0;
        UpdateText();
    }
}