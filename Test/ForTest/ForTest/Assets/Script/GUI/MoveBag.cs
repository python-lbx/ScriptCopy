using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour,IDragHandler
{
    RectTransform currentRect;

    private void Awake() 
    {
        currentRect = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        //中心錨點位置+鼠標位置
        currentRect.anchoredPosition += eventData.delta;
    }
}
