using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControler : MonoBehaviour
{
    PlayersManager PM;
    public string itemType;
    public GameObject imageItem;
    public int Type;

    private float maxDistance = 1.0f;    
    InventorySystem inventory;    
    public bool close;

    void Start()
    {        
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        inventory = GameObject.Find("Players").GetComponent<InventorySystem>();
    }
    
    
    void Update()
    {
        if (PM.Players.Count != 0)
        {
            close = PlayerClose();
            if (PlayerClose())
            {
                if (Input.GetKeyDown("e"))
                {
                    for (int i = 0; i < inventory.slots.Length; i++)
                    {
                        if (!inventory.isFull[i])
                        {
                            Instantiate(imageItem, inventory.slots[i].transform, false);
                            inventory.AddItem(gameObject, i);
                            break;
                        }
                    }
                    Destroy(gameObject);
                }

            }
        }

    }

    private bool PlayerClose()
    {
        var dist = Vector3.Distance(gameObject.transform.position, PM.Players[0].transform.position);
        return dist < maxDistance;
    }

    void SetItemType(string _itemType)
    {
        itemType = _itemType;
    }   

    
}
