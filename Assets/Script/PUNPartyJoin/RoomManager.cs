using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public TMP_Text roomCodeText; // UI para mostrar el código de la sala
    public TMP_InputField inputRoomCode; // Campo de texto para ingresar código de sala
    private string roomCode;
    private string currentRoomCode;

    void Start()
    {
        PhotonNetwork.AddCallbackTarget(this);

        if (!PhotonNetwork.IsConnected)
        {
            Debug.Log("Conectando a Photon...");
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Método para crear una sala con un código aleatorio
    public void CreateRoom()
    {
        currentRoomCode = Random.Range(1000, 9999).ToString();
        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(currentRoomCode, options);
        Debug.Log("Intentando crear la sala con código: " + currentRoomCode);
        //roomCode = Random.Range(1000, 9999).ToString(); // Genera un código de 4 dígitos
        //RoomOptions options = new RoomOptions() { MaxPlayers = 2 };
        //PhotonNetwork.CreateRoom(roomCode, options);
    }

    // Callback cuando la sala se crea con éxito
    //public override void OnCreatedRoom()
    //{
    //    string enteredCode = inputRoomCode.text;
    //    Debug.Log("Intentando unirse a la sala con código: " + enteredCode);
    //    //Debug.Log("Sala creada con código: " + roomCode);
    //    //roomCodeText.text = "Código de sala: " + roomCode; // Mostrar código en UI
    //}

    // Método para unirse a una sala ingresando el código
    public void JoinRoom()
    {
        string enteredCode = inputRoomCode.text;

        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogError("No conectado a Photon, intentando reconectar...");
            PhotonNetwork.ConnectUsingSettings();
            return;
        }

        Debug.Log("Intentando unirse a la sala con código: " + enteredCode);
        PhotonNetwork.JoinRoom(enteredCode);
        //if (!string.IsNullOrEmpty(inputRoomCode.text))
        //{
        //    PhotonNetwork.JoinRoom(inputRoomCode.text);
        //}
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Sala creada correctamente: " + PhotonNetwork.CurrentRoom.Name);
        roomCodeText.text = "Código: " + PhotonNetwork.CurrentRoom.Name;
    }

    // Callback cuando el jugador entra a la sala
    public override void OnJoinedRoom()
    {
        Debug.Log("Unido a la sala correctamente: " + PhotonNetwork.CurrentRoom.Name);

        if (PhotonNetwork.IsMasterClient)
        {
            // Si es el MasterClient, carga la escena 'SceneHarry'
            PhotonNetwork.LoadLevel("SceneHarry");
        }
        else
        {
            // Si no es el MasterClient, carga la escena 'SceneHenry'
            PhotonNetwork.LoadLevel("SceneHenry");
        }

        //PhotonNetwork.IsMessageQueueRunning = false;

        //if (PhotonNetwork.IsMasterClient)
        //{
        //    PhotonNetwork.LoadLevel("SceneHarry");
        //}
        //else // Si es el segundo jugador en unirse, carga SceneHenry
        //{
        //    PhotonNetwork.LoadLevel("SceneHenry");
        //}

        //Debug.Log("Jugadores en la sala: " + PhotonNetwork.PlayerList.Length);

        //// Si la sala ya tiene 2 jugadores, comenzar el juego
        //if (PhotonNetwork.PlayerList.Length == 2)
        //{
        //    StartGame();
        //}

        //Debug.Log("Unido a la sala: " + PhotonNetwork.CurrentRoom.Name);

        //if (PhotonNetwork.IsMasterClient)
        //{
        //    Debug.Log("Soy el host, veo la Sección A");
        //    // Aquí puedes cargar un nivel o activar una UI específica
        //}
        //else
        //{
        //    Debug.Log("Soy el cliente, veo la Sección B");
        //    // Activar otra UI o cambiar la cámara
        //}
        //Debug.Log("Unido a la sala: " + PhotonNetwork.CurrentRoom.Name);
    }

    public void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Si es el primer jugador, envía un RPC a todos para cargar sus escenas
            photonView.RPC("LoadSceneForPlayer", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer.ActorNumber);
        }
    }

    [PunRPC]
    void LoadSceneForPlayer(int playerNumber)
    {
        if (playerNumber == 1)
        {
            Debug.Log("Cargando SceneHarry para el Jugador 1...");
            SceneManager.LoadScene("SceneHarry");
        }
        else
        {
            Debug.Log("Cargando SceneHenry para el Jugador 2...");
            SceneManager.LoadScene("SceneHenry");
        }
    }

    // Callback si la sala no existe
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Error al unirse a la sala: " + message);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado a Photon con éxito.");
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log("Nuevo MasterClient: " + newMasterClient.NickName);
    }

    void OnDestroy()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
}
