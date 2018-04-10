using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler {
   public GameObject item
    {

        get { if (transform.childCount > 0) return transform.GetChild(0).gameObject; 
        return null; }
    }
    public void OnDrop(PointerEventData eventData)
    {
        //if (!item)  ItemDragHandler.ItemDragged.transform.SetParent(transform); : the Itemdragged should be eventually destroyed; in fact we should not destroy it here but inventoryListManager should destroy it because the item is moved into here.
        //TODO : modify inventory
        //
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
