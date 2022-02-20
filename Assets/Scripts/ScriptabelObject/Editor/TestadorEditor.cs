using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Maquina))]
public class MaquinaEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Maquina maquina = (Maquina)target;

        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Checar Item"))
        {
            maquina.CheckItem();
        }

        if (GUILayout.Button("Randomizar"))
        {
            maquina.RandomizeItem();
        }

        if (GUILayout.Button("Revelar Item"))
        {
            maquina.ShowItem();
        }

        GUILayout.EndHorizontal();
    }
}
