using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLR : MonoBehaviour {

    public float speed;
    public float slide;

    private Rigidbody rb;
    private InputController inputController;
    private MoveF moveF;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.drag = slide;
        inputController = GameObject.Find("Input Controller").GetComponent<InputController>();
        moveF = GameObject.Find("Game Area").GetComponent<MoveF>();
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

    void OnTriggerEnter (Collider other) {
        if (other.name.StartsWith("Split Collider"))
        {
            moveF.splitCollider = other.gameObject;
        }
    }
}
