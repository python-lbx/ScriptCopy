using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public InventoryList myBag;
    public GameObject slotGrid;
    public GameObject emptySlot;
    public Text itemInfo;
    public List<GameObject> slots = new List<GameObject>();

    // Start is called before the first frame update

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        //清空內存
        for(int i = 0 ; i<instance.myBag.ItemList.Count ; i++)
        {   
            instance.myBag.ItemList[i] = null;
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

    public static void RefreshItem()
    {
        for(int i = 0 ; i<instance.slotGrid.transform.childCount ; i++)
        {
            if(instance.slotGrid.transform.childCount == 0)
            {
                break;
            }

            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for(int i = 0 ; i<instance.myBag.ItemList.Count ; i++)
        {
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;

            instance.slots[i].GetComponent<Slot>().SetUpSlot(instance.myBag.ItemList[i]);
        }
    }
}
