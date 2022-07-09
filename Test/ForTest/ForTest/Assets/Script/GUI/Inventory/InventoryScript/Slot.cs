using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID;//空格ID = 列表ID = 物件ID
    //public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;
    public GameObject itemInSlot;

    public void ItemOnClicked()
    {
        InventoryManager.updateItemInfo(slotInfo);
    }

    public void SetUpSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        
        slotImage.sprite = item.ItemImgae;
        slotNum.text = item.ItemHeld.ToString();
        slotInfo = item.ItemInfo;
    }
}
