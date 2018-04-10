using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {
    
    Transform target;
    public Vector3 Offset { get; private set; }//singleton
    Vector3 offsetDef;
    public Text ZT;
    float zoom;
    // Use this for initialization
    void Start () {
        zoom = 1.0f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offsetDef = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
       zoom += Input.GetAxis("Mouse ScrollWheel");
       
        zoom =  Mathf.Clamp(zoom, 0.5f, 7.0f);

        Offset = offsetDef * zoom;
        ZT.text = zoom.ToString();
	}
}
