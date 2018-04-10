using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spells;


public class HotbarManager : MonoBehaviour {

    delegate void Action();

    
    private List<GameObject> weapons;
    [SerializeField] private float transTime = 2.0f;
    private float transTimeCur = 0;
    private float transTimePas = 0;
    private bool isTransTimePassed = true;
    [SerializeField] private GameObject WeaponSlot;
    private int previousWeapon = 0;
    private int selectedWeapon = 0;
    public int NumWeaponRack = 4;

   
    // Use this for initialization
    void Awake()
    {
      
        weapons = new List<GameObject>();
        for (int i = 0; i < NumWeaponRack; i++) {
            weapons.Add(Instantiate(WeaponSlot, gameObject.transform));
        }

        Animator selectedAnimator = weapons[selectedWeapon].GetComponent<Animator>();
        selectedAnimator.SetTrigger("Selected");
    }
    void numWeaponRackChange() {
        if (weapons.Count < NumWeaponRack) {
            for (int i = weapons.Count; i < NumWeaponRack; i++) {
                weapons.Add(Instantiate(WeaponSlot, gameObject.transform));
            }
        }
        if (weapons.Count > NumWeaponRack)
        {
            for (int i = NumWeaponRack; i < weapons.Count; i++)
                Destroy(weapons[i]);
                weapons.RemoveRange(NumWeaponRack, weapons.Count - NumWeaponRack); 
        }
    }
    
    void Start()
    {
        GameManager.ItemChange += itemChange;
    }
    void Attack() { }
    void Damaged() { }

    // Update is called once per frame
    void itemChange( int idx,float clock)
    {
       
        if (isTransTimePassed)
        {
            selectedWeapon = idx;
            if (selectedWeapon >= NumWeaponRack) selectedWeapon = NumWeaponRack - 1;
            print(selectedWeapon);
        }
        else
        {
            transTimeCur = clock;
            if (transTimeCur-transTimePas > transTime)
            {
                isTransTimePassed = true;
                transTimePas = transTimeCur;
            }
        }
        if (selectedWeapon != previousWeapon)
        {
            isTransTimePassed = false;
            Animator selectedAnimator = weapons[selectedWeapon].GetComponent<Animator>();
            selectedAnimator.SetTrigger("Selected");
            Animator previousAnimator = weapons[previousWeapon].GetComponent<Animator>();
            previousAnimator.SetTrigger("Disselected");
            previousWeapon = selectedWeapon;
        }
    }
    
}
