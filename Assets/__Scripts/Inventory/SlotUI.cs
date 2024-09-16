using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    private ItemSO item;

    
    public Image icon;
    public TextMeshProUGUI numText;
    private Button button;
    
    private void Start()
    {
        button = GetComponent<Button>();
        
        // todo: for farm
        button.onClick.AddListener(() => FarmModeFSM.Instance.ChangeGameMode(GameMode.Plant));
        button.onClick.AddListener(SelectThisCrop);
    }
    
    private void SelectThisCrop()
    {
        FarmModeFSM.Instance.selectedCrop = item as CropSO;
        Debug.Log("Selected " + item.name);
    }
    
    public void UpdateSlot(ItemSO item, int num)
    {
        this.item = item;
        icon.sprite = item.icon;

        if (item.stackable)
        {
            numText.text = num.ToString();
        }
        else
        {
            numText.text = "";
        }
        
    }
    
}
