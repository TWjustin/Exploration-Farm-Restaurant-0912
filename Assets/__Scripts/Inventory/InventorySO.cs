using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    
    
    

    public List<ItemSet> itemSets;


    public virtual void AddItem(ItemSO item, int num)
    {
        
        foreach (var i in itemSets)
        {
            if (i.item == item)
            {
                i.num += num;
                return;
            }
        }

        ItemSet newItemSet = new ItemSet
        {
            item = item,
            num = num, 
            durability = item is ToolSO tool ? tool.durability : 0
        };
        
        itemSets.Add(newItemSet);
    }

    
    // bool邏輯沒問題
    public virtual bool RemoveItem(ItemSO item, int num)    // 沒有maxStack
    {
        foreach (var i in itemSets)
        {
            if (i.item == item)
            {
                i.num -= num;
                if (i.num < 0)
                {
                    itemSets.Remove(i);
                    return false;
                }
                
                return true;
            }
        }
        
        return false;
        
    }
    
    public ItemSet FindItemSet(ItemSO item)
    {
        foreach (var i in itemSets)
        {
            if (i.item == item)
            {
                return i;
            }
        }

        Debug.Log("Item not found");
        return null;
    }

    
}

[Serializable]
public class ItemSet
{
    public ItemSO item;
    public int num;
    public int durability;
}