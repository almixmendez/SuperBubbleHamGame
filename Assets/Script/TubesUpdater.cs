using UnityEngine;

public class TubesUpdater : MonoBehaviour
{
    void Start()
    {
        TubeController[] tubes = FindObjectsOfType<TubeController>();
        foreach (var tube in tubes)
        {
            //tube.ApplyRotationFromData();
        }
    }
}
