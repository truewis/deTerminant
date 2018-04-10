using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float doubleClickInterval = 0.1f;
    private float clickInterval=0;

	Rigidbody playerRigidbody;
    UnityEngine.AI.NavMeshAgent navAgent;
	int floorMask;
	float camRayLength = 1000f;

	// Use this for initialization
	void Start () {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    void FixedUpdate () {

        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (clickInterval < doubleClickInterval)
                {
                    Debug.Log("Dash!");
                }
                clickInterval = 0;
            }
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit floorHit;
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                navAgent.destination = floorHit.point;
            }
        }
        clickInterval += Time.deltaTime;
	}
}