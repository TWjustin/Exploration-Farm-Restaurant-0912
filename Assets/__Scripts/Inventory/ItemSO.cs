using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// do not need to create asset menu
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int price;
    
    public ItemType itemType;
    
    public bool stackable;
}

public enum ItemType
{
    Default,
    RawMaterial,
    Seed,
    Tool,
}