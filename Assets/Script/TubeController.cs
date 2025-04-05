using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TubeController : MonoBehaviour
{
    public int id;
    public TubesData data;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;

        TubeInfo info = data.GetTubeInfoById(id);

        if (info != null)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, info.rotation);
        }
        else
        {
            Debug.LogWarning($"No se encontró un tubo con ID {id} en el ScriptableObject.");
        }
        //if (data != null)
        //{
        //    TubeInfo info = data.GetTubeInfoById(id);
        //    if (info != null)
        //    {
        //        transform.rotation = Quaternion.Euler(0f, 0f, info.rotation);
        //    }
        //}
    }

    void Update()
    {
        // Fijar la posición siempre
        transform.position = initialPosition;
    }

    public void RotateTube()
    {
        //transform.position = initialPosition;

        // Rotamos en Z (en el lugar)
        transform.Rotate(0f, 0f, 90f);

        TubeInfo info = data.GetTubeInfoById(id);
        if (info != null)
        {
            info.rotation = transform.eulerAngles.z;
        }

        //// Guardamos la nueva rotación en el SO
        //if (data != null)
        //{
        //    TubeInfo info = data.GetTubeInfoById(id);
        //    if (info != null)
        //    {
        //        info.rotation = transform.eulerAngles.z;
        //    }
        //}
    }

    void LateUpdate()
    {
        transform.position = initialPosition;
    }
}
