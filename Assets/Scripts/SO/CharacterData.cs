using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Object/Character Data", order = 0)]
public class CharacterData : ScriptableObject
{
    [Header("info")]
    [SerializeField] private string playerName;
    [SerializeField] private string charName;
    [SerializeField] private int level;
    [SerializeField] private int exp;

    [Header("Status")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float power;
    [SerializeField] private float armor;
    [SerializeField] private float critical;


}
