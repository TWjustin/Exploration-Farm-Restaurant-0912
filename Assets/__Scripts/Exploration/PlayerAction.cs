using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour
{

    private ItemSO heldItem;
    public ToolSO scythe;   // test
    public ToolSO axe;   // test
    public ToolSO pickaxe;   // test
    
    public BoxCollider2D boxCollider2D;
    public Button actBtn;
    public Image actBtnImage;
    
    private Resource resource;
    private List<Resource> resources = new List<Resource>();
    
    


    private void Start()
    {
        heldItem = scythe;
        
        actBtn.onClick.AddListener(UseTool);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            resource = other.GetComponent<Resource>();
            resources.Add(resource);
            
            switch (resource.resourceType)
            {
                case ResourceType.Bush:
                    heldItem = scythe;
                    break;
                case ResourceType.Tree:
                    heldItem = axe;
                    break;
                case ResourceType.Rock:
                    heldItem = pickaxe;
                    break;
                default:
                    heldItem = null;
                    break;
            }

            if (heldItem != null)
            {
                actBtnImage.sprite = heldItem.icon;
            }
            
            
        }
    }
    
    private void UseTool()
    {
        (heldItem as ToolSO)?.Use(resource);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            resources.Remove(other.GetComponent<Resource>());
            
            if (resources.Count > 0)
            {
                resource = resources[0];
                switch (resource.resourceType)
                {
                    case ResourceType.Bush:
                        heldItem = scythe;
                        break;
                    case ResourceType.Tree:
                        heldItem = axe;
                        break;
                    case ResourceType.Rock:
                        heldItem = pickaxe;
                        break;
                    default:
                        heldItem = null;
                        break;
                }
                
                if (heldItem != null)
                {
                    actBtnImage.sprite = heldItem.icon;
                }
            }
            else
            {
                actBtnImage.sprite = null;
                heldItem = null;
            }
            
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxCollider2D.size);
    }
}
