using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploGameManager : MonoBehaviour
{
    public GameObject inventoryGameObject;
    
    public GameObject optionPanel;
    
    public SlotUI currentSlot;
    
    #region Singleton

    public static ExploGameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion


    private void Start()
    {
        inventoryGameObject.GetComponentInParent<InventoryUI>().inventory.ItemSets = new List<ItemSet>();
        inventoryGameObject.SetActive(false);
    }
    
    public void OpenOptionPanel(SlotUI slot)
    {
        optionPanel.SetActive(true);
        currentSlot = slot;
        optionPanel.transform.position = slot.transform.position + new Vector3(45, -75, 0);
    }
}
