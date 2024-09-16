using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool", menuName = "Items/Tool")]
public class ToolSO : ItemSO
{
    public ToolType toolType;
    public int strength;  // 強度，單次使用造成的傷害
    public int efficiency;  // 效率，時間減少比例
    public int durability;  // 耐久度，使用一次減一
    
    
    
    public void Use(Resource resource)
    {
        if (resource.requiredTool == this)
        {
            Resources.Load<ExplorInvenSO>("TrophyInven").AddItemSets(resource.dropItems);
                
            durability--;
            Destroy(resource.gameObject);
        }
    }
    
}


public enum ToolType
{
    Default,
    Scythe,
}