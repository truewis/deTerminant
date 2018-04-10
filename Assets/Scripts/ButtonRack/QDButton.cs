using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QDButton : MonoBehaviour
{

    Button but;
    [SerializeField] GameObject InvScreen;
    [SerializeField] GameObject CraftScreen;
    [SerializeField] GameObject SkillScreen;
    [SerializeField] GameObject QDScreen;
    // Use this for initialization
    void Start()
    {
        but = GetComponent<Button>();
        but.onClick.AddListener(SwitchPanel);
       
    }
    void SwitchPanel()
    {
        QDScreen.SetActive(!QDScreen.activeSelf);
        InvScreen.SetActive(false); SkillScreen.SetActive(false); CraftScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
