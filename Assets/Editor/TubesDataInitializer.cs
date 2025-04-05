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

        asset.tubes[0] = new TubeInfo { id = 3, rotation = 0f };
        asset.tubes[1] = new TubeInfo { id = 4, rotation = 0f };
        asset.tubes[2] = new TubeInfo { id = 8, rotation = 0f };
        asset.tubes[3] = new TubeInfo { id = 12, rotation = 0f };

        // Guardar como archivo
        string path = "Assets/TubesData.asset";
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

        Debug.Log(" TubesData.asset creado e inicializado con 4 tubos.");
    }
}
