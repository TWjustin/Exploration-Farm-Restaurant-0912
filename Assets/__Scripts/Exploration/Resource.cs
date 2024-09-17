using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ResourceType
{
    Default,
    Tree,
    Rock,
    Bush,   // 小植物
    Animal,
    FruitTree,
}

public class Resource : MonoBehaviour
{
    public ResourceType resourceType;

    public int hp;
    public GameObject hpBarPrefab;
    public GameObject hpBar;
    public float hpBarOffset = 1f;
    
    public ToolSO requiredTool;
    public List<ItemSet> dropItems;


    private void Start()
    {
        gameObject.tag = "Interactable";

        // if (hp > 1)
        // {
        //     hpBar = Instantiate(hpBarPrefab, transform.position + Vector3.up * hpBarOffset, Quaternion.identity);
        //     hpBar.transform.SetParent(transform);
        //     hpBar.SetActive(false);
        // }
        
        hpBar = Instantiate(hpBarPrefab, transform.position + Vector3.up * hpBarOffset, Quaternion.identity);
        hpBar.transform.SetParent(transform);
        hpBar.SetActive(false);
        
    }
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        hpBar.SetActive(true);

        if (hp <= 0)
        {
            DoWhenHpZero();
        }
    }
    

    private void DoWhenHpZero()
    {
        ExplorInvenSO inventory = Resources.Load<ExplorInvenSO>("TrophyInven");
        
        inventory.AddItemSets(dropItems);
        Destroy(gameObject);
    }
}
