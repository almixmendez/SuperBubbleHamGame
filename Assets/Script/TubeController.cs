using UnityEngine;

public class TubeController : MonoBehaviour
{
    public int id;
    public TubesData data;
    private TubeInfo info;
    private Vector3 initialPosition;

    void Start()
    {
        info = data.GetTubeInfoById(id);
        if (info == null)
        {
            Debug.LogWarning($"No se encontr� info para tubo con ID {id} en {gameObject.name}");
            return;
        }

        initialPosition = transform.position; // Guardamos la posici�n original
        ApplyRotation();
        //if (data != null)
        //{
        //    TubeInfo targetTube = System.Array.Find(data.tubes, t => t.id == id);

        //    if (targetTube != null)
        //    {
        //        //float angle = targetTube.rotation;
        //        transform.rotation = Quaternion.Euler(0f, 0f, targetTube.rotation);
        //    }
        //    else
        //    {
        //        Debug.LogWarning($" No se encontr� tubo con ID {id} en la escena Tubes.");
        //    }
        //if (data != null && id < data.tubes.Length)
        //{
        //    float angle = data.tubes[id].rotation;
        //    Debug.Log("Tubo " + id + " en escena 'Tubes' se carg� con rotaci�n: " + angle);
        //    transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //}
    }

    void Update()
    {
#if UNITY_EDITOR
        if (transform.position != initialPosition)
        {
            transform.position = initialPosition; // Evitamos que se mueva
        }
#endif
        ApplyRotation();
    }

    void ApplyRotation()
    {
        if (info != null)
        {
            // Solo rotamos en Z
            transform.rotation = Quaternion.Euler(0, 0, info.rotation);
        }
    }

    public void Rotate(float angle)
    {
        if (info != null)
        {
            info.rotation += angle;
            Debug.Log($"Tubo {id} rotado a {info.rotation}");
        }
    }

    //public void RotateTube()
    //{
    //    // Guardamos la posici�n para mantenerlo fijo
    //    Vector3 originalPosition = transform.position;

    //    // Rotamos 90 grados sobre su propio eje Z
    //    transform.Rotate(Vector3.forward * 90f, Space.Self);

    //    // Guardamos el nuevo �ngulo en el ScriptableObject
    //    if (data != null)
    //    {
    //        TubeInfo targetTube = System.Array.Find(data.tubes, t => t.id == id);
    //        if (targetTube != null)
    //        {
    //            targetTube.rotation = transform.eulerAngles.z;
    //        }
    //    }

    //    // Restauramos la posici�n para que no se desplace
    //    transform.position = originalPosition;
    //}
        //transform.Rotate(0f, 0f, 90f);

        //if (data != null)
        //{
        //    TubeInfo targetTube = System.Array.Find(data.tubes, t => t.id == id);

        //    if (targetTube != null)
        //    {
        //        targetTube.rotation = transform.eulerAngles.z;
        //    }
        //}

        //if (data != null && id < data.tubes.Length)
        //{
        //    data.tubes[id].rotation = transform.eulerAngles.z;
        //}
}