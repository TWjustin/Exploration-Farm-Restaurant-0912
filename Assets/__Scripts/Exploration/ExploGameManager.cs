using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploGameManager : MonoBehaviour
{
    public GameObject inventoryGameObject;

    private void Start()
    {
        inventoryGameObject.SetActive(false);
    }
}
