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
        button.onClick.AddListener(() => GameModeFSM.Instance.ChangeGameMode(GameMode.Plant));
        button.onClick.AddListener(SelectThisCrop);
    }
    
    private void SelectThisCrop()
    {
        GameModeFSM.Instance.selectedCrop = (CropSO) item;
        Debug.Log("Selected " + item.name);
    }
    
    public void UpdateSlot(ItemSO item, int num)
    {
        this.item = item;
        icon.sprite = item.icon;
        numText.text = num.ToString();
    }
    
}
