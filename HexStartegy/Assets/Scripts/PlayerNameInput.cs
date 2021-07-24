using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class PlayerNameInput : MonoBehaviour
{
    private InputField _inputField;

    private string playerName;
    private void Awake()
    {
        _inputField = GetComponent<InputField>();
        _inputField.onEndEdit.AddListener(delegate{FinishedWriting();});
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
            _inputField.text = playerName;
            PhotonNetwork.NickName = playerName;
        }
    }
    
    private void FinishedWriting()
    {
        if (_inputField.text.IsNullOrEmpty())
        {
            return;
        }

        PhotonNetwork.NickName = _inputField.text;
        PlayerPrefs.SetString("PlayerName", _inputField.text);
    }
}
