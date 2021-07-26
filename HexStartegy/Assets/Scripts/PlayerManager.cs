using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.EventSystems;
using Hashtable = System.Collections.Hashtable;

public enum Kingdoms
{
    Vikings,
    Barbarians,
    Spartans
}
public class PlayerManager : MonoBehaviour
{
    ExitGames.Client.Photon.Hashtable customProperty = new ExitGames.Client.Photon.Hashtable();
    public static PlayerManager localPlayerInstance;
    public Kingdoms playerKingdom;
    [HideInInspector] public PhotonView photonView;
    
    private PlayerUI _playerUI;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        _playerUI = GetComponentInChildren<PlayerUI>();
        
        if (photonView.IsMine)
        {
            localPlayerInstance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _playerUI.SetTarget(this);
    }

    public void SetKingdom(Kingdoms kingdom)
    {
        playerKingdom = kingdom;
        
        customProperty["Kingdom"] = kingdom;
        // sync to players
        PhotonNetwork.LocalPlayer.SetCustomProperties(customProperty, null, null);
    }

    private void OnMouseDown()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["Kingdom"]);
    }
}
