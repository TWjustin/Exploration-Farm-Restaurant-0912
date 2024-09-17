using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SlotUI : MonoBehaviour
{
    
    
    public ItemSet itemSet;

    
    public Image icon;
    public TextMeshProUGUI numText;
    protected Button button;
    
    
    
    protected virtual void Start()
    {
        
        button = GetComponent<Button>();
        
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "FarmScene":
                
                button.onClick.AddListener(SelectCrop);
                break;
            
            case "ExplorationScene":
                
                button.onClick.AddListener(() => ExploGameManager.Instance.OpenOptionPanel(this));
                break;
            
            case "AnimalScene":
                
                break;
        }
        
        
    }
    
    private void SelectCrop()
    {
        FarmModeFSM.Instance.ChangeGameMode(GameMode.Plant);
        
        ItemSO item = itemSet.item;
        FarmModeFSM.Instance.selectedCrop = item as CropSO;
        Debug.Log("Selected " + item.name);
    }
    
    
    
    public void UpdateSlot(ItemSet i)
    {
        ItemSO item = i.item;
        
        itemSet = i;
        icon.sprite = item.icon;

        if (item.stackable)
        {
            numText.text = i.num.ToString();
        }
        else
        {
            numText.text = "";
        }
        
    }
    
}
