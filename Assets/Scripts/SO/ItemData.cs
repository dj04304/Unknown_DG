using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Helm,
    shoes
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object / Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public int item_id;
    public string itemName;
    public string description;
    public int status;
    public bool isEquiped;
    public ItemType itemType;
    public Sprite icon;
    public GameObject prefab;


}
