using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TubesData))]

public class TubesDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TubesData data = (TubesData)target;

        if (data.tubes == null)
        {
            data.tubes = new TubeInfo[0];
        }

        EditorGUILayout.LabelField("Editor de Tubos", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        for (int i = 0; i < data.tubes.Length; i++)
        {
            EditorGUILayout.BeginVertical("box");

            data.tubes[i].id = EditorGUILayout.IntField("ID", data.tubes[i].id);
            data.tubes[i].rotation = EditorGUILayout.FloatField("Rotación", data.tubes[i].rotation);

            if (GUILayout.Button("Resetear rotación"))
            {
                data.tubes[i].rotation = 0f;
            }

            if (GUILayout.Button("Eliminar este tubo"))
            {
                var list = new System.Collections.Generic.List<TubeInfo>(data.tubes);
                list.RemoveAt(i);
                data.tubes = list.ToArray();
                break;
            }

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Agregar nuevo tubo"))
        {
            var list = new System.Collections.Generic.List<TubeInfo>(data.tubes);
            list.Add(new TubeInfo { id = data.tubes.Length, rotation = 0f });
            data.tubes = list.ToArray();
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(data);
        }
    }
}
