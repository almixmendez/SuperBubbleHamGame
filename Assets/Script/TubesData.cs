using UnityEngine;

[CreateAssetMenu(fileName = "TubesData", menuName = "Shared Data/TubesData")]
public class TubesData : ScriptableObject
{

    public TubeInfo[] tubes;
    public TubeInfo[] tubess;
}

[System.Serializable]
public class TubeInfo
{
    public int id; // Identificador �nico del tubo
    public float rotation; // Rotaci�n en grados
}