using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public Text roomCodeText; // UI para mostrar el c�digo de la sala
    public InputField inputRoomCode; // Campo de texto para ingresar c�digo de sala
    private string roomCode;

    // M�todo para crear una sala con un c�digo aleatorio
    public void CreateRoom()
    {
        roomCode = Random.Range(1000, 9999).ToString(); // Genera un c�digo de 4 d�gitos
        RoomOptions options = new RoomOptions() { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(roomCode, options);
    }

    // Callback cuando la sala se crea con �xito
    public override void OnCreatedRoom()
    {
        Debug.Log("Sala creada con c�digo: " + roomCode);
        roomCodeText.text = "C�digo de sala: " + roomCode; // Mostrar c�digo en UI
    }

    // M�todo para unirse a una sala ingresando el c�digo
    public void JoinRoom()
    {
        if (!string.IsNullOrEmpty(inputRoomCode.text))
        {
            PhotonNetwork.JoinRoom(inputRoomCode.text);
        }
    }

    // Callback cuando el jugador entra a la sala
    public override void OnJoinedRoom()
    {
        Debug.Log("Unido a la sala: " + PhotonNetwork.CurrentRoom.Name);
    }

    // Callback si la sala no existe
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Error al unirse a la sala: " + message);
    }
}
