using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public InventoryList playerInventory;
    

    bool here;

    // Start is called before the first frame update
    private void Update() 
    {
        if(here && Input.GetKeyDown(KeyCode.Q))
        {
            if(FindObjectOfType<InventoryManager>().isfull)
            {
                FindObjectOfType<InventoryManager>().itemInfo.text = "背包滿了";
            }

            AddNewItem();

        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //print(other.gameObject.name);
            here = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //print(other.gameObject.name);
            here = false;
        }    
    }

    public void AddNewItem()
    {
        //避免重覆
        /*if(!playerInventory.ItemList.Contains(thisItem)){}*/ 
        
        for(int i = 0 ; i < playerInventory.ItemList.Count ; i++)
        {
            if(playerInventory.ItemList[i] == null)
            {
                playerInventory.ItemList[i] = thisItem;
                Destroy(this.gameObject);
                break;
            }
        }

        InventoryManager.RefreshItem();
    }
}
