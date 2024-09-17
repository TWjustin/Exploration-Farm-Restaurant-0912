using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    
    public ItemSO[] testItems;  // test
    
    
    
    public InventorySO inventory;
    public Transform content;
    public GameObject slotPrefab;
    
    
    private void Awake()
    {
        inventory.OnItemChanged += UpdateInven;
    }

    

    private void UpdateInven()
    {
        ClearInven();
        Debug.Log("UpdateInven");
        
        for (int i = 0; i < inventory.ItemSets.Count; i++)
        {
            GameObject slot = Instantiate(slotPrefab, content);
            ItemSet itemSet = inventory.ItemSets[i];
            slot.GetComponent<SlotUI>().UpdateSlot(itemSet);
        }
    }
    
    private void ClearInven()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
    
    
    
    public void Test()
    {
        inventory.AddItem(testItems[0], 9);
    }
    
}