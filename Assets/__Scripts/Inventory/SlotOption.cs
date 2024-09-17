using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotOption : MonoBehaviour
{
    public Button equipBtn;
    public Button discardBtn;
    
    public QuickSlotUI[] quickSlots;

    private void Start()
    {
        gameObject.SetActive(false);
        
        equipBtn.onClick.AddListener(Equip);
        discardBtn.onClick.AddListener(Discard);
    }

    private void Equip()
    {
        foreach (var quickSlot in quickSlots)
        {
            if (quickSlot.correspondingSlot == null)
            {
                SlotUI s = ExploGameManager.Instance.currentSlot;
                quickSlot.correspondingSlot = s;
                quickSlot.UpdateSlot(s.itemSet);
                break;
            }
        }
        
        gameObject.SetActive(false);
    }
    
    private void Discard()
    {
        GetComponentInParent<InventoryUI>().inventory.DiscardItem(ExploGameManager.Instance.currentSlot);
        
        gameObject.SetActive(false);
    }
}
