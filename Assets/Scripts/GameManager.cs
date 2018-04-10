using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public class tag
    {
        public string tagID;
        public int value;
        public tag(string ID, int val) {
            tagID = ID;
            value = val;
        }
        public bool isEqualTag(tag other) {
            if (other.tagID == tagID && other.value == value) return true;
            return false;

        }
    }
    public uint itemID { get; private set; }
    //item type mask : first byte of the itemID
    const int WEAPON = 0x00;
    const int ARMOR = 0x01;
    const int ACSORY = 0x02;
    const int CONSUM = 0x03;
    const int TOOL = 0x04;
    const int MAT = 0x05;
    //the first byte is a item type and the other bytes are item subtype mask
    /*first byte
     * second byte
     *0x00 : weapon
     * 
     *0x01 : armor
     *0x02 : accessory
     *0x03 : consummable
     *0x04 : tool
     *0x05 : Material 
     * 
     *
     * 
     * */
    public int amount;
    public List<tag> tags;
    /*
    bool IsSameType(Item x) {
        if(x.itemID==itemID&&x.tags)
        return false;

    }
    */
    public Item(uint ID, int amt, List<tag> tagList) {
        itemID = ID;
        amount = amt;
        foreach (tag t in tagList) tags.Add(new tag(t.tagID, t.value));

    }
    public Item(Item i)
    {
        itemID = i.itemID;
        amount = i.amount;
        foreach (tag t in i.tags) tags.Add(new tag(t.tagID, t.value));

    }
    public bool isMergable(Item other) {
        if(itemID >> 24 == CONSUM || itemID >> 24 == MAT )
        if (other.itemID == itemID)
            if (other.tags.Count == tags.Count)
            {
                for (int i = 0; i < other.tags.Count; i++) { if (!tags[i].isEqualTag(other.tags[i])) return false; }
                return true;
            }
        return false;
    }
}
public class GameManager : MonoBehaviour
{
    public delegate void vActionIntFloat(int i, float f);
    public static vActionIntFloat ItemChange;

    public List<Item> Inventory { get; private set; }

    class inventoryComp : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {

            if (x.itemID > y.itemID) return 1;
            if (x.itemID < y.itemID) return -1;
            return 0;
        }
    }
    void inventorySort()
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            for (int j = i + 1; j < Inventory.Count; j++)
            {
                if (Inventory[i].isMergable(Inventory[j])) { Inventory[i].amount += Inventory[j].amount; Inventory.RemoveAt(j); }

            }

        }
        Inventory.Sort(new inventoryComp());

    }
    public void inventoryAdd(Item i) {
        Inventory.Add(i);


    }
    public void inventoryDelete(Item i)
    {
        Inventory.Add(i);


    }
    void inventoryInit()//debug function
    {
        Item i = new Item(1, 1, new List<Item.tag>());
        inventoryAdd(i);
    }
    private static GameManager sInstance;

    public static GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (sInstance == null)
                {
                    Debug.Log("Nothing" + sInstance.ToString());
                    return null;
                }

            }

            return sInstance;


        }

    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != this) Destroy(gameObject);
        Inventory = new List<Item>();
        inventoryInit();

    }






    // Update is called once per frame
    void Update()
    {

    }
}
