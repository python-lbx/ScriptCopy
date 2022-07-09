using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "" , menuName =("Inventory/New Item"))]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public int ItemHeld;
    [TextArea]
    public string ItemInfo;
}
