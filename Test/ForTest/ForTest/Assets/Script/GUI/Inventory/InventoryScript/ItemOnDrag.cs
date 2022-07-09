using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //鼠標點擊插件

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;
    public inventory mybag;
    public int currentItemID;//當前物品ID

    public void OnBeginDrag(PointerEventData eventData) //開始
    {   
        originalParent = transform.parent;
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent);//升級
        transform.position = eventData.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) //過程
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name); //輸出鼠標下物件名字

        if(eventData.pointerCurrentRaycast.gameObject == null)
        {
            print("null");
        }
        
    }

    public void OnEndDrag(PointerEventData eventData) //結束
    {

            if(eventData.pointerCurrentRaycast.gameObject.name == "ItemImage" && eventData.pointerCurrentRaycast.gameObject != null) //如果有物件
            {
                //實現物件交換
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent); //Slot/Item/ItemImage
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
                //itemList物品存儲位置改變 ID對調
                var temp = mybag.itemList[currentItemID]; //暫時存放鼠標底下物件ID
                mybag.itemList[currentItemID] = mybag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID]; //找到鼠標底下物件對應ID,進行調換
                mybag.itemList[eventData.pointerPressRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp; 

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if(eventData.pointerCurrentRaycast.gameObject.name == "slot(Clone)" && eventData.pointerCurrentRaycast.gameObject != null) //判定為物品欄才執行
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform); //slot
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //itemList物品存儲位置改變

                mybag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = mybag.itemList[currentItemID];
                //如果ID不相同 即更換位置 則原位置清空
                if(eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                {
                    mybag.itemList[currentItemID] = null;
                }

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            else
            {
                //其他任何位置都歸位
                transform.SetParent(originalParent);
                transform.position = originalParent.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
            }


        
    }
}
