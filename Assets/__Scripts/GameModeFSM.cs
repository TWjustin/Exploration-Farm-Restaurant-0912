using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameMode
{
    Default,
    PlantMenu,
    Plant,
    Harvest,
}

public class GameModeFSM : MonoBehaviour
{
    public GameMode currentMode;
    
    
    // default mode
    public Button plantMenuButton;
    public Button harvestButton;
    
    // plant menu mode
    public Button backButtonInPlantMenuMode;
    
    // plant mode
    public Button backButtonInPlantMode;
    public Button doneButtonInPlantMode;
    
    // harvest mode
    public Button harvestDoneButton;
    
    
    public GameObject plantMenu;
    public GameObject plantBtnParent;
    public GameObject mainBtnParent;
    public GameObject harvestDoneBtnGO;
    
    [HideInInspector] public CropSO selectedCrop;
    
    
    #region Singleton

    public static GameModeFSM Instance { get; set; }

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
        plantMenuButton.onClick.AddListener(() => ChangeGameMode(GameMode.PlantMenu));
        harvestButton.onClick.AddListener(() => ChangeGameMode(GameMode.Harvest));
        backButtonInPlantMenuMode.onClick.AddListener(() => ChangeGameMode(GameMode.Default));
        backButtonInPlantMode.onClick.AddListener(() => ChangeGameMode(GameMode.PlantMenu));
        doneButtonInPlantMode.onClick.AddListener(() => ChangeGameMode(GameMode.Default));
        harvestDoneButton.onClick.AddListener(() => ChangeGameMode(GameMode.Default));
        
        ChangeGameMode(GameMode.Default);
    }
    
    // 模式切換邏輯
    public void ChangeGameMode(GameMode newMode)
    {
        currentMode = newMode;
        Debug.Log("Game Mode changed to: " + currentMode.ToString());

        // 根據模式進行不同的邏輯處理
        switch (currentMode)
        {
            case GameMode.Default:
                EnterDefaultMode();
                break;
            case GameMode.PlantMenu:
                EnterPlantMenuMode();
                break;
            case GameMode.Plant:
                EnterPlantMode();
                break;
            case GameMode.Harvest:
                EnterHarvestMode();
                break;
        }
    }
    
    private void EnterDefaultMode()
    {
        plantMenu.SetActive(false);
        plantBtnParent.SetActive(false);
        mainBtnParent.SetActive(true);
        harvestDoneBtnGO.SetActive(false);
    }
    
    private void EnterPlantMenuMode()
    {
        plantMenu.SetActive(true);
        plantBtnParent.SetActive(false);
        mainBtnParent.SetActive(false);
    }
    
    private void EnterPlantMode()
    {
        plantMenu.SetActive(false);
        plantBtnParent.SetActive(true);
        mainBtnParent.SetActive(false);
    }
    
    private void EnterHarvestMode()
    {
        mainBtnParent.SetActive(false);
        harvestDoneBtnGO.SetActive(true);
    }
}
