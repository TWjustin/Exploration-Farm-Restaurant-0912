using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public InventorySO inventory;
    
    private CropSO crop;

    public SpriteRenderer plant;    // 植物體子物件
    public bool isPlanted = false;
    public bool isRipe = false;

    private int currentStage = 0;
    private float timer;
    
    public Material normalMat;
    public Material outlineMat;
    
    

    private void Start()
    {
        plant.gameObject.SetActive(false);

        FarmModeFSM.Instance.OnEnterPlantMode += HighLightIfAvailable;
        FarmModeFSM.Instance.OnEnterHarvestMode += HighLightIfRipe;
    }

    private void OnMouseDown()  //
    {
        switch (FarmModeFSM.Instance.currentMode)
        {
            case GameMode.Plant:
                if (!isPlanted)
                {
                    bool available = inventory.RemoveItem(FarmModeFSM.Instance.selectedCrop, 1);

                    if (available)
                    {
                        Plant(FarmModeFSM.Instance.selectedCrop);
                    }
                }
                else
                {
                    Debug.Log("Plot is already planted");
                }
                break;
            
            case GameMode.Harvest:
                if (isPlanted)
                {
                    if (isRipe)
                    {
                        inventory.AddItem(crop.product, crop.productNum);
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

            isRipe = currentStage == crop.plantStagesSprites.Length - 1;
            
            if (timer <= 0 && !isRipe)
            {
                timer = crop.timeBtwStages;
                currentStage++;
                UpdatePlant();
            }
        }
    }
    
    private void HighLightIfAvailable()
    {
        if (!isPlanted)
        {
            ChangeMat(transform, outlineMat);
        }
    }
    
    private void HighLightIfRipe()
    {
        if (isRipe)
        {
            ChangeMat(transform.GetChild(0), outlineMat);
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
        ChangeMat(transform, normalMat);
    }

    private void UpdatePlant()
    {
        plant.sprite = crop.plantStagesSprites[currentStage];
    }

    private void Harvest()
    {
        isPlanted = false;
        isRipe = false;
        plant.gameObject.SetActive(false);
        crop = null;
        ChangeMat(transform.GetChild(0), normalMat);
    }
    
    
    private void ChangeMat(Transform tf, Material mat)
    {
        SpriteRenderer sr = tf.GetComponent<SpriteRenderer>();
        sr.material = mat;
    }
}