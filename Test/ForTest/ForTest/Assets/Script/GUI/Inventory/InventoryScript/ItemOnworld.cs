using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnworld : MonoBehaviour
{
    public Item thisItem;
    public inventory playerInventory;

    Collider2D coll;
    
    private void Start() 
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            print(playerInventory.itemList + thisItem.name);
            Destroy(this.gameObject);
            
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem)) //如果這背包里沒有這個物件
        {
            //playerInventory.itemList.Add(thisItem); //加入背包
            //InventoryManager.createnewItem(thisItem);

            for(int i = 0 ; i < playerInventory.itemList.Count ; i++)
            {
                if(playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.ItemHeld ++; //數量+1
        }

        InventoryManager.RefreshItem();
    }
}
