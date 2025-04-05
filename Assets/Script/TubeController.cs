using UnityEngine;

public class TubeController : MonoBehaviour
{
    public int id;
    public TubesData data;

    void Start()
    {
        if (data != null)
        {
            TubeInfo targetTube = System.Array.Find(data.tubes, t => t.id == id);

            if (targetTube != null)
            {
                float angle = targetTube.rotation;
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                Debug.LogWarning($" No se encontró tubo con ID {id} en la escena Tubes.");
            }
            //if (data != null && id < data.tubes.Length)
            //{
            //    float angle = data.tubes[id].rotation;
            //    Debug.Log("Tubo " + id + " en escena 'Tubes' se cargó con rotación: " + angle);
            //    transform.rotation = Quaternion.Euler(0f, 0f, angle);
            //}
        }
    }

    public void RotateTube()
    {
        transform.Rotate(0f, 0f, 90f);

        if (data != null)
        {
            TubeInfo targetTube = System.Array.Find(data.tubes, t => t.id == id);

            if (targetTube != null)
            {
                targetTube.rotation = transform.eulerAngles.z;
            }
        }

        //if (data != null && id < data.tubes.Length)
        //{
        //    data.tubes[id].rotation = transform.eulerAngles.z;
        //}
    }
}

