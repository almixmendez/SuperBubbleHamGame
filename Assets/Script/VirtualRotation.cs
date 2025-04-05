using UnityEngine;

public class VirtualRotation : MonoBehaviour
{
    public TubesData data;

    public void VirtuallyRotateByID(int id)
    {
        if (data != null)
        {
            TubeInfo targetTube = System.Array.Find(data.tubes, t => t.id == id);

            if (targetTube != null)
            {
                targetTube.rotation += 90f;
                if (targetTube.rotation >= 360f)
                    targetTube.rotation = 0f;

                Debug.Log($" Bot�n presionado - Tubo ID: {id} - Nueva rotaci�n: {targetTube.rotation}");
            }
            else
            {
                Debug.LogWarning($" No se encontr� un tubo con ID {id} en el TubesData.");
            }
        }
        //        if (data != null && id < data.tubes.Length)
        //        {
        //            data.tubes[id].rotation += 90f;
        //            if (data.tubes[id].rotation >= 360f)
        //                data.tubes[id].rotation = 0f;

        //            #if UNITY_EDITOR
        //            UnityEditor.EditorUtility.SetDirty(data);
        //            UnityEditor.AssetDatabase.SaveAssets();
        //#endif

        //            Debug.Log("Tubo " + id + " rotado virtualmente a: " + data.tubes[id].rotation);
        //            Debug.Log($" Bot�n presionado - Tubo ID: {id} - Nueva rotaci�n: {data.tubes[id].rotation}");
        //        }
        //        else
        //        {
        //            Debug.LogWarning($" No se pudo rotar tubo con ID {id}. Verifica si el array est� inicializado correctamente.");
        //        }
    }
}
