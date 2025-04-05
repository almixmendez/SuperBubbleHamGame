using UnityEngine;
using UnityEditor;

public class TubesDataInitializer
{
    [MenuItem("Tools/Inicializar TubesData")]
    public static void CreateAndInitializeTubesData()
    {
        // Crear el asset
        TubesData asset = ScriptableObject.CreateInstance<TubesData>();

        // Inicializar 4 tubos
        asset.tubes = new TubeInfo[4];
        for (int i = 0; i < 4; i++)
        {
            asset.tubes[i] = new TubeInfo();
            asset.tubes[i].id = i;
            asset.tubes[i].rotation = 0f;
        }

        // Guardar como archivo
        string path = "Assets/TubesData.asset";
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

        Debug.Log(" TubesData.asset creado e inicializado con 4 tubos.");
    }
}
