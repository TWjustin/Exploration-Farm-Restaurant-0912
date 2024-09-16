using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [Serializable]
// public struct DropItemSet
// {
//     public ItemSO item;
//     public int num;
// }

public class Resource : MonoBehaviour
{
    public ToolSO requiredTool;
    
    
    public List<ItemSet> dropItems;


    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }
}
