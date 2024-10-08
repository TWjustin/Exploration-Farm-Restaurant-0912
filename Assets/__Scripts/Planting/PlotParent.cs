using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotParent : MonoBehaviour
{
    
    public GameObject plotPrefab;
    public Vector2 startPos;
    public int columns = 7;
    public int rows = 3;
    

    
    // 初始化地块
    private void Start()
    {
        
        
        InitializePlot();
        
    }

    private void InitializePlot()
    {
        startPos = transform.position;
        
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector2 pos = new Vector2(startPos.x + i * 2f, startPos.y - j * 2f);
                GameObject plot = Instantiate(plotPrefab, pos, Quaternion.identity);
                plot.transform.SetParent(transform);
            }
        }
    }

    
    
    
}