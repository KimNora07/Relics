using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data/New Item")]
public class ItemData : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public int cost;
    public int atk;

    public ItemTypes selectedItemType = new ItemTypes();
    public enum ItemTypes
    {
        Sword,
        Armor,
        Usable
    }
}
