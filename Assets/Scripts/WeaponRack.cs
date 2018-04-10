using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemRack : MonoBehaviour {
    Image ItemImage;
    Button But;
    Text WeaponName;
	// Use this for initialization
	void Start () {
        But = GetComponent<Button>();
        ItemImage = GetComponent<Image>();
        WeaponName = GetComponentInChildren<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
