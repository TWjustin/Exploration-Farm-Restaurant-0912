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


        if (resourceType != ResourceType.Bush)
        {
            hpBar = Instantiate(hpBarPrefab, transform.position + Vector3.up * hpBarOffset, Quaternion.identity);
            hpBar.transform.SetParent(transform);
            hpBar.SetActive(false);
        }
        
    }
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hpBar != null)
        {
            hpBar.SetActive(true);
        }
        

        if (hp <= 0)
        {
            DoWhenHpZero();
        }
    }
    

    protected virtual void DoWhenHpZero()
    {
        ExplorInvenSO inventory = Resources.Load<ExplorInvenSO>("TrophyInven");//
        
        inventory.AddItemSets(dropItems);
        Destroy(gameObject);
    }
}
