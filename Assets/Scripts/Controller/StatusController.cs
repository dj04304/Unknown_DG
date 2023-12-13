using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public TextMeshProUGUI characterPower;
    public TextMeshProUGUI characterArmor;
    public TextMeshProUGUI characterMaxHealth;
    public TextMeshProUGUI characterCritical;

    private ItemData itemData;
    public Character character;

    private void Start()
    {
        BaseStatus();
    }


    private void BaseStatus()
    {
        characterPower.text = character.CharacterData.power.ToString();
        characterArmor.text = character.CharacterData.armor.ToString();
        characterMaxHealth.text = character.CharacterData.maxHealth.ToString();
        characterCritical.text = character.CharacterData.critical.ToString();
    }

    public void UpdateStatus(ItemData itemData)
    {
        if(itemData != null)
        {
            // 착용 중일시
            if(itemData.isEquiped)
            {
                Debug.Log("왔니?: " + itemData.status);

                if(itemData.itemType == ItemType.Weapon)
                {
                    characterPower.text = (float.Parse(characterPower.text) + itemData.status).ToString();
                }
                else
                {
                    characterArmor.text = (float.Parse(characterArmor.text) + itemData.status).ToString();
                }

            }
            else if(!itemData.isEquiped)
            {
                if (itemData.itemType == ItemType.Weapon)
                {
                    characterPower.text = (float.Parse(characterPower.text) - itemData.status).ToString();
                }
                else
                {
                    characterArmor.text = (float.Parse(characterArmor.text) - itemData.status).ToString();
                }

            }
        }

    }
}
