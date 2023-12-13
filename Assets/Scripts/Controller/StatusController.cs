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

    [SerializeField] private List<ItemData> itemDataList;
    public Character character;

    private void Start()
    {
        BaseStatus();
    }


    private void BaseStatus()
    {
        float curEquipPower = character.CharacterData.power;
        float curEquipArmor = character.CharacterData.armor;

        Debug.Log(" curEquipPower " + curEquipPower);
        Debug.Log(" curEquipArmor " + curEquipArmor);

        foreach (ItemData item in itemDataList)
        {
            if(item.isEquiped)
            {
                if(item.itemType == ItemType.Weapon)
                {
                    curEquipPower += item.status;

                }
                else if(item.itemType == ItemType.Armor)
                {
                    curEquipArmor += item.status;
                }
            }
        }

        characterPower.text = curEquipPower.ToString();
        characterArmor.text = curEquipArmor.ToString();
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

    private void UpdateCharacterDataFromUI()
    {
        character.CharacterData.power = float.Parse(characterPower.text);
        character.CharacterData.armor = float.Parse(characterArmor.text);
    }


    public void SaveStatusOnClick()
    {
        UpdateCharacterDataFromUI();

        SaveStatus();
        Debug.Log("Json파일에 저장중입니다!");
    }

    private void SaveStatus()
    {
        PlayerJsonLoad.Instance.SavePlayerDataToJson(character.CharacterData);
    }
}
