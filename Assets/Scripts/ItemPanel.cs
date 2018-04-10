using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour {
    public Item holdingItem { get; set; }
    public void setItem(Item i) {
        holdingItem = new Item(i);
    }
	// Use this for initialization
	void Start () {
		//generate draggedItemImage & textItemImage here
	}
	
	
}
