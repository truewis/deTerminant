using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeymapManager : MonoBehaviour {
	public static KeymapManager root;
	public Dictionary<string/*action*/, KeyCode/*keycode*/> keymap = new Dictionary<string, KeyCode>();
	public Dictionary<int/*name*/, int/*value*/> settings = new Dictionary<int, int>();
	// Use this for initialization

	void Start () {
        DontDestroyOnLoad(gameObject);
        if (root == null) root = this;
		else Destroy(this);
		asterisk0s();
       
	}
	private void asterisk0s()
	{
		keymap.Add("asterisk00", KeyCode.W);
		keymap.Add("asterisk01", KeyCode.E);
		keymap.Add("asterisk02", KeyCode.D);
		keymap.Add("asterisk03", KeyCode.S);
		keymap.Add("asterisk04", KeyCode.A);
		keymap.Add("asterisk05", KeyCode.Q);
	}
    private void hotbar()
    {
        keymap.Add("weapon1", KeyCode.Alpha1);
        keymap.Add("weapon2", KeyCode.Alpha2);
        keymap.Add("weapon3", KeyCode.Alpha3);
        keymap.Add("weapon4", KeyCode.Alpha4);
        keymap.Add("thing1", KeyCode.Alpha5);
        keymap.Add("thing2", KeyCode.Alpha6);
        keymap.Add("thing3", KeyCode.Alpha7);
        keymap.Add("thing4", KeyCode.Alpha8);
    }
    private void asterisk1s()
	{
		keymap.Add("asterisk10", KeyCode.I);
		keymap.Add("asterisk11", KeyCode.O);
		keymap.Add("asterisk12", KeyCode.L);
		keymap.Add("asterisk13", KeyCode.K);
		keymap.Add("asterisk14", KeyCode.J);
		keymap.Add("asterisk15", KeyCode.U);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
