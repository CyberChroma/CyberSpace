using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLR : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private InputController inputController;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        inputController = GameObject.Find("Input Controller").GetComponent<InputController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveDir = 0;
        if (inputController.inputL)
        {
            moveDir = -1;
        }
        else if (inputController.inputR)
        {
            moveDir = 1;
        }
        rb.AddForce (transform.right * moveDir * speed * 10);
        transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0); 
	}
}
