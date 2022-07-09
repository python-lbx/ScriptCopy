using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public inventory myBag; //連接到背包資料庫
    public GameObject slotGrid; //連接到背包介面
    //public Slot slotPrefab; //物件預置
    public GameObject emptySlot;
    public Text itemInfo;  //背包中物件描述

    public List<GameObject> slots = new List<GameObject>();//新列表

    private void Awake() {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void OnEnable() 
    {
        RefreshItem();
        instance.itemInfo.text = "";
    }

    public static void updateItemInfo(string ItemDescription)
    {
        instance.itemInfo.text = ItemDescription;
    }

    public static void CleanItemInfo()
    {
        instance.itemInfo.text = "";
    }
    
    /*public static void createnewItem(Item item) //取得物件資料
    {
        //生成預置物在背包介面
        Slot newitem = Instantiate(instance.slotPrefab,instance.slotGrid.transform.position,Quaternion.identity); 
        //成為背包UI下的子物件
        newitem.gameObject.transform.SetParent(instance.slotGrid.transform); 
        newitem.slotItem = item;
        newitem.slotImage.sprite = item.ItemImgae;
        newitem.slotNum.text = item.ItemHeld.ToString(); 
    }*/

    public static void RefreshItem()
    {
        //清除數據
        for(int i = 0 ; i< instance.slotGrid.transform.childCount ; i++)
        {
            if(instance.slotGrid.transform.childCount == 0)
            {
                break;
            }

            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
            
        }
        //刷新
        for(int i = 0 ; i < instance.myBag.itemList.Count ; i++)
        {
            //生成背包格於對應位置
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            //背包中的物件資料傳送
            instance.slots[i].GetComponent<Slot>().SetUpSlot(instance.myBag.itemList[i]);
        }
    }
}
