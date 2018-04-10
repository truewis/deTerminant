using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemList : MonoBehaviour, IDropHandler, IPointerEnterHandler
{

    
    public void OnDrop(PointerEventData eventData)
    {
        //TODO : modify inventory
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
