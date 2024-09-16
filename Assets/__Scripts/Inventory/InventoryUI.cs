using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    
    public ItemSO[] testItems;
    
    
    
    
    public InventorySO inventory;
    public GameObject slotPrefab;


    private void OnEnable()
    {
        UpdateInven();
    }
    

    public void UpdateInven()
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
    
    
    
    public void Test()
    {
        inventory.AddItem(testItems[0], 9);
        UpdateInven();
    }
    
}