using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance;
    public UnityEvent onConnectedToRoom;
    [SerializeField] private Room room;

    private void Awake()
    {
        if (room == null)
            room = FindObjectOfType<Room>();

        if (!Instance)
            Instance = this;

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to servers");
    }

    public void HostLobby(string lobbyName, byte playerAmount)
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.JoinOrCreateRoom(lobbyName, new RoomOptions {MaxPlayers = playerAmount, IsVisible = false}, null);
        }
        
    }
    public override void OnJoinedRoom()
    {
        onConnectedToRoom?.Invoke();
        room.SpawnPlayer();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        room.SpawnPlayer(newPlayer);
    }
}
