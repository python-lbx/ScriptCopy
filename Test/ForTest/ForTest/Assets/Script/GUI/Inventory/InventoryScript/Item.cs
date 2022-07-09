using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Inventory/New Item")] //新建項目默認名稱,層級自設
public class Item : ScriptableObject
{
    //物件資料庫
    public string ItemName;//物件名
    public Sprite ItemImgae;//物件圖
    public int ItemHeld;//物件數量
    [TextArea]
    public string ItemInfo;//物件資訊欄
    public bool equie;//能否裝備
}
