using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public InventorySO inventory;
    
    private CropSO crop;

    private bool isPlanted = false;
    public SpriteRenderer plant;    // 植物體子物件

    private int currentStage = 0;
    private float timer;

    private void Start()
    {
        plant.gameObject.SetActive(false);
    }

    private void OnMouseDown()  //
    {
        switch (GameModeFSM.Instance.currentMode)
        {
            case GameMode.Plant:
                if (!isPlanted)
                {
                    Plant(GameModeFSM.Instance.selectedCrop);
                    inventory.RemoveItem(GameModeFSM.Instance.selectedCrop, 1);
                }
                else
                {
                    Debug.Log("Plot is already planted");
                }
                break;
            case GameMode.Harvest:
                if (isPlanted)
                {
                    if (currentStage == crop.plantStagesSprites.Length - 1)
                    {
                        Harvest();
                    }
                    else
                    {
                        Debug.Log("Plant is not ready yet");
                    }
                }
                else
                {
                    Debug.Log("Plot is empty");
                }
                break;
            default:
                break;
        }
        
    }

    private void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer <= 0 && currentStage < crop.plantStagesSprites.Length - 1)
            {
                timer = crop.timeBtwStages;
                currentStage++;
                UpdatePlant();
            }
        }
    }

    private void Plant(CropSO newCrop)
    {
        crop = newCrop;
        isPlanted = true;
        currentStage = 0;
        UpdatePlant();
        timer = crop.timeBtwStages;
        plant.gameObject.SetActive(true);
    }

    private void UpdatePlant()
    {
        plant.sprite = crop.plantStagesSprites[currentStage];
    }

    private void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }


}