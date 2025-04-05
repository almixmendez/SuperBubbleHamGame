using UnityEngine;

[CreateAssetMenu(fileName = "TubesData", menuName = "Shared Data/TubesData")]
public class TubesData : ScriptableObject
{
    public TubeInfo[] tubes;

    public TubeInfo GetTubeInfoById(int id)
    {
        foreach (var tube in tubes)
        {
            if (tube.id == id)
                return tube;
        }
        return null;
    }
}

[System.Serializable]
public class TubeInfo
{
    public int id; // Identificador único del tubo
    public float rotation; // Rotación en grados
}