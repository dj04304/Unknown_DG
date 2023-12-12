using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipPopupBtn : MonoBehaviour
{
    private ItemData itemData;
    public GameObject equipPopup;
    private InventoryItem equipItem;

    private bool isEquiped;

    // ���޹��� ������ ����
    public void SendItemData(ItemData selectedItemData, InventoryItem item)
    {
        //Debug.Log("�ȵǳ�");
        itemData = selectedItemData;
        //Debug.Log("isEquiped" + itemData.isEquiped);

        equipItem = item;
    }

    public void OnConfirmBtnClicked()
    {
        Debug.Log("equiped?: " + itemData);

        isEquiped = !isEquiped;
        itemData.isEquiped = isEquiped;


        SetEquipedImage();

        equipPopup.SetActive(false);
    }

    public void OnCancelBtnClicked()
    {
        equipPopup.SetActive(false);
    }

    // ������ �̹��� ��ȯ
    private void SetEquipedImage()
    {
        if(itemData != null)
        {
            //Transform equipImage = itemData.prefab.transform.GetChild(0);
            //Debug.Log("equipImage" + equipImage);

            Debug.Log("inventoryItem: " + equipItem);
            Debug.Log("itemData.isEquiped: " + itemData.isEquiped);
            equipItem.SetEquipItem(itemData.isEquiped);

            //equipImage.gameObject.SetActive(itemData.isEquiped);
            //Debug.Log(itemData.isEquiped);

        }
    }

}
