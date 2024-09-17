using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotUI : SlotUI
{
    public PlayerAction playerAction;
    public InventorySO inventory;
    
    public SlotUI correspondingSlot;
    
    protected override void Start()
    {
        inventory.OnItemChanged += CorrespondSlot;
        
        button = GetComponent<Button>();
        button.onClick.AddListener(Select);
    }

    private void Select()
    {
        if (itemSet != null)
        {
            playerAction.foragingState = false;
            playerAction.heldItem = itemSet.item;
            
        }
    }
    
    private void CorrespondSlot()
    {
        if (correspondingSlot != null)
        {
            correspondingSlot.itemSet = itemSet;
            UpdateSlot(itemSet);
        }
        else
        {
            icon.sprite = null;
            numText.text = "";
        }
    }
    
    
}
