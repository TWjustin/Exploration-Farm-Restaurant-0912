using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventorySO : ScriptableObject
{
    public List<ItemSet> ItemSets;
    
    
    public event Action OnItemChanged;

    


    public virtual void AddItem(ItemSO item, int num)
    {
        
        foreach (var i in ItemSets)
        {
            if (i.item == item)
            {
                i.num += num;
                
                CallUpdateInven();
                return;
            }
        }

        ItemSet newItemSet = new ItemSet
        {
            item = item,
            num = num, 
            durability = item is ToolSO tool ? tool.durability : 0
        };
        
        ItemSets.Add(newItemSet);
        CallUpdateInven();
        
    }

    
    // bool邏輯沒問題
    public bool RemoveItem(ItemSO item, int num)
    {
        foreach (var i in ItemSets)
        {
            if (i.item == item)
            {
                int newNum = i.num - num;
                if (newNum <= 0)
                {
                    return false;
                }
                
                
                i.num -= num;
                CallUpdateInven();
                return true;
            }
        }
        
        Debug.Log("Item not found");
        return false;
        
    }
    
    public ItemSet FindItemSet(ItemSO item)
    {
        foreach (var i in ItemSets)
        {
            if (i.item == item)
            {
                return i;
            }
        }

        Debug.Log("Item not found");
        return null;
    }

    
    protected void CallUpdateInven()
    {
        OnItemChanged?.Invoke();
    }
    
}

[Serializable]
public class ItemSet
{
    public ItemSO item;
    public int num;
    public int durability;
}