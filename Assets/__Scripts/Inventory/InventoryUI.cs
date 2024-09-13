using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySO inventory;
    public GameObject slotPrefab;
    
    private void Start()
    {
        UpdateInven();
    }

    private void UpdateInven()
    {
        ClearInven();
        
        for (int i = 0; i < inventory.itemSets.Count; i++)
        {
            GameObject slot = Instantiate(slotPrefab, transform);
            slot.GetComponent<SlotUI>().UpdateSlot(inventory.itemSets[i].item, inventory.itemSets[i].num);
        }
    }
    
    private void ClearInven()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    
}