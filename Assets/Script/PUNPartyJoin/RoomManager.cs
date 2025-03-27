using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TMP_Text roomCodeText; // UI para mostrar el código de la sala
    public TMP_InputField inputRoomCode; // Campo de texto para ingresar código de sala
    private string roomCode;

    // Método para crear una sala con un código aleatorio
    public void CreateRoom()
    {
        string generatedCode = Random.Range(1000, 9999).ToString(); // Código aleatorio
        roomCodeText.text = "Código: " + generatedCode;
        //roomCode = Random.Range(1000, 9999).ToString(); // Genera un código de 4 dígitos
        //RoomOptions options = new RoomOptions() { MaxPlayers = 2 };
        //PhotonNetwork.CreateRoom(roomCode, options);
    }

    // Callback cuando la sala se crea con éxito
    public override void OnCreatedRoom()
    {
        string enteredCode = inputRoomCode.text;
        Debug.Log("Intentando unirse a la sala con código: " + enteredCode);
        //Debug.Log("Sala creada con código: " + roomCode);
        //roomCodeText.text = "Código de sala: " + roomCode; // Mostrar código en UI
    }

    // Método para unirse a una sala ingresando el código
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

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Soy el host, veo la Sección A");
            // Aquí puedes cargar un nivel o activar una UI específica
        }
        else
        {
            Debug.Log("Soy el cliente, veo la Sección B");
            // Activar otra UI o cambiar la cámara
        }
        //Debug.Log("Unido a la sala: " + PhotonNetwork.CurrentRoom.Name);
    }

    // Callback si la sala no existe
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Error al unirse a la sala: " + message);
    }
}
