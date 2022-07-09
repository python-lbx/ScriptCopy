using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory",menuName = "Inventory/New Inventory")]
public class inventory : ScriptableObject
{
    //背包資料庫
    public List<Item> itemList = new List<Item>(); //正式寫法
}
