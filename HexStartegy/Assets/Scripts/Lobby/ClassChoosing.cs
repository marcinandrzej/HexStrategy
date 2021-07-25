using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassChoosing : MonoBehaviour
{

    public void ChooseClass(int id)
    {
        Kingdoms kingdom = (Kingdoms)id;
        PlayerManager.localPlayerInstance.SetKingdom(kingdom);
    }
}
