using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    private PlayerManager target;

    public void SetTarget(PlayerManager _target)
    {
        target = _target;
        playerName.text = target.photonView.Owner.NickName;
    }
}
