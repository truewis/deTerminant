using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour {
    [SerializeField]private GameObject itemPanel;
    private Transform content;
    List<GameObject> itemPanels;//currently displayed panels
	// Use this for initialization
	void Start () {
        itemPanels = new List<GameObject>();
        content = transform.GetChild(0).GetChild(0);
	}
	
	
    void refresh() {
        //TODO : implement filters
        itemPanels.Clear();
        foreach (Item i in GameManager.Instance.Inventory) {
            GameObject tmpPanel = Instantiate(itemPanel, content);
            ItemPanel tmp = tmpPanel.GetComponent<ItemPanel>();
            tmp.setItem(i);
            itemPanels.Add(tmpPanel);

        }
        

    }
}
