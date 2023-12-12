using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipPopupBtn : MonoBehaviour
{
    public GameObject equipPopup;

    private bool isEquiped;

    public void OnConfirmBtnClicked()
    {
        equipPopup.SetActive(false);
    }

    public void OnCancelBtnClicked()
    {
        isEquiped = !isEquiped;
        equipPopup.SetActive(false);
    }



}
