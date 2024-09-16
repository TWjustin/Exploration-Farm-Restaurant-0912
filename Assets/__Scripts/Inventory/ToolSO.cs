using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Items/Tool/Default")]
public class ToolSO : ItemSO
{
    public ToolType toolType;
    public ResourceType handlingesourceType;
    
    public int strength;  // 強度，單次使用造成的傷害
    public int efficiency;  // 效率，時間減少比例
    public int durability;  // 耐久度，使用一次減一
    
    public void Use(Resource resource)
    {
        ExplorInvenSO inventory = Resources.Load<ExplorInvenSO>("TrophyInven");
        
        ItemSet toolItemSet = inventory.itemSets.Find(i => i.item == this);
        
        if (resource.resourceType == handlingesourceType && toolItemSet != null)
        {
            
            inventory.FindItemSet(this).durability--;
            
            // varies here
                
            inventory.AddItemSets(resource.dropItems);
            Destroy(resource.gameObject);
                
            if (toolItemSet.durability <= 0)
            {
                inventory.RemoveItem(this, 1);
            }
            
            
        }
        else
        {
            Debug.Log("工具無法使用在這個物件上");
        }
    }
    
    
    
}


public enum ToolType
{
    Default,
    Scythe,
}