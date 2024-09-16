using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ResourceType
{
    Default,
    Tree,
    Rock,
    Bush,   // 小植物
    Animal,
}

public class Resource : MonoBehaviour
{
    public ResourceType resourceType;
    
    
    public List<ItemSet> dropItems;


    private void Start()
    {
        gameObject.tag = "Interactable";
    }
}
