using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
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
        else if (GameModeFSM.Instance.currentMode == GameMode.Plant)
        {
            Plant(GameModeFSM.Instance.selectedCrop);
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