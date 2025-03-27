using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Prefab del jugador que se instanciará
    public string player1PrefabName = "Hamster1"; // Prefab del jugador 1
    public string player2PrefabName = "Hamster2"; // Prefab del jugador 2
    public Transform spawnPoint; // Punto donde aparece el jugador

    void Start()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            string prefabToSpawn = PhotonNetwork.IsMasterClient ? player1PrefabName : player2PrefabName;
            PhotonNetwork.Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
            //PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity);
        }
    }
}
