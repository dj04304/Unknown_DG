using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GameObject icon;

    public void SetEquipItem(bool isEquiped)
    {
        if(isEquiped)
        {
            Debug.Log("123421313");
            icon.SetActive(true);
        }
        else
        {
            icon.SetActive(false);
        }
        
    }

}
