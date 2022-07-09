using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;
    public InventoryList mybag;
    public int currentItemID;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent);
        transform.position = eventData.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {   
        var obj = eventData.pointerCurrentRaycast.gameObject;

            if(obj.name == "ItemImage" && obj != null)
            {
                transform.SetParent(obj.transform.parent.parent);
                transform.position = obj.transform.position;
                var temp = mybag.ItemList[currentItemID];
                mybag.ItemList[currentItemID] = mybag.ItemList[obj.GetComponentInParent<Slot>().slotID];
                mybag.ItemList[obj.GetComponentInParent<Slot>().slotID] = temp;

                obj.transform.parent.position = originalParent.position;
                obj.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if(obj.name == "Slot(Clone)" && obj != null)
            {
                transform.SetParent(obj.transform);
                transform.position = obj.transform.position;

                mybag.ItemList[obj.GetComponentInParent<Slot>().slotID] = mybag.ItemList[currentItemID];

                if(obj.GetComponent<Slot>().slotID != currentItemID)
                {
                    mybag.ItemList[currentItemID] = null;
                }

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            else
            {
                transform.SetParent(originalParent);
                transform.position = originalParent.position;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
    }
}
