using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterInfoController : MonoBehaviour
{
    public TextMeshProUGUI playerCharName;
    public TextMeshProUGUI playerOccupation;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerLv;
    public TextMeshProUGUI playerDescription;

    public Character character;

    private void Start()
    {
        InfoPrint();
    }

    private void InfoPrint()
    {
        playerCharName.text = character.CharacterData.charName;
        playerOccupation.text = character.CharacterData.occupation;
        playerName.text = character.CharacterData.playerName;
        playerLv.text = character.CharacterData.level.ToString("00");
        playerDescription.text = character.CharacterData.description;

    }
}
