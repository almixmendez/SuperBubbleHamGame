using UnityEngine;

public class TubeGizmoVisualizer : MonoBehaviour
{
    public TubesData data; // Vinculá tu ScriptableObject desde el Inspector

    public float tubeSize = 1f;
    public Color gizmoColor = Color.cyan;

    private void OnDrawGizmos()
    {
        if (data == null || data.tubes == null) return;

        Gizmos.color = gizmoColor;

        for (int i = 0; i < data.tubes.Length; i++)
        {
            Vector3 pos = transform.position + new Vector3(i * 2f, 0, 0); // Separa los tubos visualmente
            Quaternion rot = Quaternion.Euler(0, 0, data.tubes[i].rotation);

            // Dibujar el tubo como una flecha
            Vector3 dir = rot * Vector3.up;
            Gizmos.DrawLine(pos, pos + dir * tubeSize);
            Gizmos.DrawSphere(pos, 0.1f);

            // Mostrar texto del ID
#if UNITY_EDITOR
            UnityEditor.Handles.Label(pos + Vector3.up * 0.5f, $"ID: {data.tubes[i].id} ({data.tubes[i].rotation}°)");
#endif
        }
    }
}
