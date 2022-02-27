using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnMonsters))]
public class RoomCreaturesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SpawnMonsters r = (SpawnMonsters)target;

        if(GUILayout.Button("Update All"))
        {
            r.UpdateAll();
        }
    }
}