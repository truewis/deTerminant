using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemDragHandler : MonoBehaviour , IBeginDragHandler,IDragHandler,IEndDragHandler{
    public static GameObject ItemDragged;
    Image itemImage;
    GameObject itemChildImage;
    Vector3 startPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemDragged = gameObject;
        startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        itemChildImage.SetActive(true);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemChildImage.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //this method could not be called because the holder could be destroyed.
        //this method is only called when the item is not moved eventually.
        //throw when dragged to the outer view.
        
        ItemDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        itemChildImage.SetActive(false);


    }

    // Use this for initialization
    void Start () {
        itemImage = GetComponentInChildren<Image>();
        itemChildImage = transform.GetChild(0).gameObject;
	}
	
	
}
