using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestSystem))]
public class QuestLineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        QuestSystem targetQS = (QuestSystem)target;

        if(GUILayout.Button("Update Quest"))
        {
            targetQS.UpdateText();
        }

        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Next Quest"))
        {
            targetQS.NextQuest();
        }

        if (GUILayout.Button("Previous Quest"))
        {
            targetQS.PreviousQuest();
        }

        GUILayout.EndHorizontal();

        if (GUILayout.Button("Reset Quest"))
        {
            targetQS.ResetQuest();
        }
    }
}
