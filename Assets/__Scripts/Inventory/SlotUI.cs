using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI numText;
    
    
    public void UpdateSlot(ItemSO item, int num)
    {
        icon.sprite = item.icon;
        numText.text = num.ToString();
    }
}
