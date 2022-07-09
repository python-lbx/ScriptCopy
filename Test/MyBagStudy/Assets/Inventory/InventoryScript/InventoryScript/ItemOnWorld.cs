using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public InventoryList playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(this.gameObject);
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.ItemList.Contains(thisItem))
        {
            for(int i = 0 ; i < playerInventory.ItemList.Count ; i++)
            {
                if(playerInventory.ItemList[i] == null)
                {
                    playerInventory.ItemList[i] = thisItem;
                    break;
                }
            }
        }

        InventoryManager.RefreshItem();
    }
}
