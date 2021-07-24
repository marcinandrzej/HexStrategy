using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static GameObject localPlayerInstance;
    
    [HideInInspector] public PhotonView photonView;
    private PlayerUI _playerUI;
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        _playerUI = GetComponentInChildren<PlayerUI>();
        
        if (photonView.IsMine)
        {
            localPlayerInstance = this.gameObject;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _playerUI.SetTarget(this);
    }
}
