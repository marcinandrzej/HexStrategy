using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Hashtable = System.Collections.Hashtable;

public enum Kingdoms
{
    Vikings,
    Samurais,
    Spartans
}
public class PlayerManager : MonoBehaviour
{
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
        
        if (photonView.Owner.CustomProperties.ContainsKey("Kingdom"))
        {
            photonView.Owner.CustomProperties["Kingdom"] = kingdom;
        }
        else
        {
            ExitGames.Client.Photon.Hashtable customProperty = new ExitGames.Client.Photon.Hashtable();
            customProperty.Add("Kingdom", kingdom);
            photonView.Owner.SetCustomProperties(customProperty, null, null);
        }

        Debug.Log("Player: " + photonView.Owner.NickName + " have choosen: " + kingdom.ToString());
    }
}
