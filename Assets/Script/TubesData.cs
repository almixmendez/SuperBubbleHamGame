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
    public int id; // Identificador �nico del tubo
    public float rotation; // Rotaci�n en grados
}