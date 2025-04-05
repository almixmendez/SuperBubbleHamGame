using UnityEngine;

public class VirtualRotation : MonoBehaviour
{
    public TubesData data;

    //public void RotateAndUpdate(int id)
    //{
    //    VirtuallyRotateByID(id);

    //    // Actualizar los objetos visibles en escena
    //    TubeController[] tubes = FindObjectsOfType<TubeController>();
    //    foreach (var tube in tubes)
    //    {
    //        if (tube.id == id)
    //            tube.ApplyRotationFromData();
    //    }
    //}

    public void VirtuallyRotateByID(int id)
    {
        if (data == null) return;

        TubeInfo tube = data.GetTubeInfoById(id);
        if (tube != null)
        {
            tube.rotation += 90f;
            if (tube.rotation >= 360f)
                tube.rotation = 0f;

            Debug.Log($"Botón presionado - Tubo ID: {id} - Nueva rotación: {tube.rotation}");
        }
        //if (data != null)
        //{
        //    TubeInfo tube = System.Array.Find(data.tubes, t => t.id == id);
        //    if (tube != null)
        //    {
        //        tube.rotation += 90f;
        //        if (tube.rotation >= 360f)
        //            tube.rotation = 0f;

        //        Debug.Log($"[VirtualRotation] Tubo {id} virtualmente rotado a {tube.rotation}");
        //    }
        //}
    }
}
