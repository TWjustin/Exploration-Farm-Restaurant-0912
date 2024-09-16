using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scythe", menuName = "Items/Tool/Scythe")]
public class ScytheSO : ToolSO
{
    
    
    private void Awake()
    {
        handlingesourceType = ResourceType.Bush;
    }

    
}
