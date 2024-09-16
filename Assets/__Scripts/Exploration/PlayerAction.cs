using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public ExplorInvenSO inventory;
    
    private ItemSO heldItem;
    public ToolSO scythe;   // test
    
    public float interactRange = 1f;
    public LayerMask interactLayer;

    private void Start()
    {
        heldItem = scythe;
    }

    public void Interact()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactRange, interactLayer);
        
            
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);

            (heldItem as ToolSO)?.Use(hit.collider.GetComponent<Resource>());
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * interactRange);
    }
}
