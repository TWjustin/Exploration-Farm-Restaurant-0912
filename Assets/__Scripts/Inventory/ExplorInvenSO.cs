using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Exploration Inventory", menuName = "Inventory/Exploration Inventory")]
public class ExplorInvenSO : InventorySO
{
    public int maxStack;
    public int maxSlot;
    


    public void AddItemSets(List<ItemSet> itemSets)
    {
        foreach (var itemSet in itemSets)
        {
            AddItem(itemSet.item, itemSet.num);
        }
    }
    
    
    public override void AddItem(ItemSO item, int num)
    {
        if (item.stackable)
        {
            foreach (var i in ItemSets)
            {
                if (i.item == item)
                {
                    i.num += num;
                    
                    if (i.num > maxStack)
                    {
                        int remain = i.num - maxStack;
                        i.num = maxStack;
                        NewItemSet(item, remain);
                    }
                    
                    return;
                }
            }
        }
        
        NewItemSet(item, num);

        
    }
    
    private void NewItemSet(ItemSO item, int num)
    {
        if (ItemSets.Count < maxSlot)
        {
            ItemSet newItemSet = new ItemSet
            {
                item = item,
                num = num
            };
        
            ItemSets.Add(newItemSet);
            CallUpdateInven();
        }
        else
        {
            Debug.Log("Inventory is full");
        }
        
        
    }
    
    
}
