using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class Room : MonoBehaviour
{
    public Text lobbyNameText = null;
    public Text playerAmountText = null;
    public Text playerNameText = null;
    
    [SerializeField] private GameObject lobbyAnimations  = null;
    [SerializeField] private List<GameObject> spawnPoint;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void HostRoom()
    {
        if (playerNameText.text.IsNullOrEmpty())
        {
            Debug.Log("Setup player name before hosting");
            return;
        }

        if (lobbyNameText.text.IsNullOrEmpty())
        {
            Debug.Log("Setup lobby name before hosting");
            return;
        }
        
        Byte playersNumber = Byte.Parse(playerAmountText.text);
        NetworkManager.Instance.HostLobby(lobbyNameText.text, playersNumber);
    }

    public void SpawnPlayer(Player newPlayer = null)
    {
        if(PlayerManager.localPlayerInstance == null)
            PhotonNetwork.Instantiate(GameManager.Instance.playerPrefab.name, spawnPoint[PhotonNetwork.PlayerList.Length-1].transform.position + new Vector3(0, .1f, 0), Quaternion.identity, 0);
    }
}
