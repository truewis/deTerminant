using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
	public struct LimbStatus
	{
		int maxHealth, health;
		float damageLevel;
		float burnLevel;
		float frostLevel;
		float paralyzedLevel;
		public int useable()
		{
			return 10;
			// TODO limb useable calculaton
		}
	}
	public struct BodyStatus
	{
		LimbStatus head, body, lArm, rArm, lLeg, rLeg;
	}

    public BodyStatus bodyStatus;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
