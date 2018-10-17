using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed = 2;
    public float moveTime = 2;
    public Vector3 startDir = Vector3.right;

    private Vector3 dir;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        dir = startDir;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(WaitToChangeDir());
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
