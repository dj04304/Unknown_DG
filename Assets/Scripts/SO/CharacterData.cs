using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Object/Character Data", order = 0)]
public class CharacterData : ScriptableObject
{
    [Header("info")]
    public string playerName;

    [SerializeField] private string _charName;
    public string charName
    {
        get { return _charName; }
    }

    public int level;
    public int exp;

    [Header("Status")]
    public float maxHealth;
    public float power;
    public float armor;
    public float critical;

}
