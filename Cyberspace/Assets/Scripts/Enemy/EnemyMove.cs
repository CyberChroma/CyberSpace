using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed = 2;
    public float moveTime = 2;
    public Vector3 startDir = Vector3.right;

    private Vector3 dir;
    private Rigidbody rb;
    private Vector3 startPos;
    private Quaternion startRot;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

	void OnEnable () {
        dir = startDir;
        StartCoroutine(WaitToChangeDir());
	}

    void OnDisable () {
        transform.position = startPos;
        transform.rotation = startRot;
    }

	// Update is called once per frame
	void FixedUpdate () {
        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
	}

    IEnumerator WaitToChangeDir () {
        yield return new WaitForSeconds(moveTime);
        ChangeDir();
    }

    void ChangeDir () {
        dir *= -1;
        StartCoroutine(WaitToChangeDir());
    }
}
