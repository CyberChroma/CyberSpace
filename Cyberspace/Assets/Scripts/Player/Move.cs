using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed;
    public float weight;

    private Rigidbody rb;
    private InputManager inputManager;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        inputManager = FindObjectOfType<InputManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveDir = 0;
        if (inputManager.inputR)
        {
            moveDir = 1;
        }
        else if (inputManager.inputL)
        {
            moveDir = -1;
        }
        rb.AddForce ((transform.right * moveDir * speed * 10) + (-transform.up * weight * 10));
        rb.velocity *= 0.99f;
	}
}
