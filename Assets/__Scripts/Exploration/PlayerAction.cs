using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{
    public bool foragingState = true;

    private ItemSO heldItem;
    
    public BoxCollider2D boxCollider2D;
    public Button actBtn;
    public Image actBtnImage;
    
    private Resource resource;
    private List<Resource> resourceList = new List<Resource>();
    
    


    private void Start()
    {
        actBtn.onClick.AddListener(UseTool);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable") && foragingState)
        {
            resource = other.GetComponent<Resource>();
            resourceList.Add(resource);

            heldItem = resource.requiredTool;

            if (heldItem != null)
            {
                actBtnImage.sprite = heldItem.icon;
                actBtn.interactable = true;
            }
            
            
        }
    }
    
    private void UseTool()
    {
        if (heldItem is ToolSO tool)
        {
            tool.Use(resource);
        }
        
    }
    
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            resourceList.Remove(other.GetComponent<Resource>());
            
            if (resourceList.Count > 0)
            {
                resource = resourceList[0];
                
                heldItem = resource.requiredTool;
                
                if (heldItem != null)
                {
                    actBtnImage.sprite = heldItem.icon;
                    actBtn.interactable = true;
                }
            }
            else
            {
                actBtnImage.sprite = null;
                heldItem = null;
                actBtn.interactable = false;
            }
            
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxCollider2D.size);
    }
}
