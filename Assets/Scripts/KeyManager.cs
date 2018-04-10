using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyManager : MonoBehaviour {
    
    private static KeyManager sInstance;

    public static KeyManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType(typeof(KeyManager)) as KeyManager;
                if (sInstance == null)
                {
                    Debug.Log("Nothing" + sInstance.ToString());
                    return null;
                }

            }

            return sInstance;


        }

    }
    // Use this for initialization
    
    string[] HexKeyNames = new string[] { "Hex(U)", "Hex(UL)", "Hex(LL)", "Hex(L)", "Hex(LR)", "Hex(UR)"};
    string[] HotbarKeyNames = new string[] { "HotbarWeapon1", "HotbarWeapon2", "HotbarWeapon3", "HotbarWeapon4", "HotbarItem1", "HotbarItem2", "HotbarItem3", "HotbarItem4" };
    private float keyClock = 0;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != this) Destroy(gameObject);
        
    }
   

    // Update is called once per frame
    void Update () {
        keyClock += Time.deltaTime;
        /*
        for(int i=0;i<HexKeyNames.Length;i++)
            if (Input.GetButton(HexKeyNames[i])) { }
            */

        for (int i = 0; i < HotbarKeyNames.Length; i++)
            if (Input.GetButton(HotbarKeyNames[i])) { GameManager.ItemChange(i, keyClock); }
    }
}
