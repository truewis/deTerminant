using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public float speed = 3f;
	Transform target;
	
    CameraZoom scr;
	// Use this for initialization
	void Start () {
        scr = GetComponent<CameraZoom>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.position + scr.Offset, speed * Time.deltaTime);
	}
}
