using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed;
    public bool startRight;
    public float dirChangeTime;
    public float downDis;

    private float dir;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        if (startRight)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
        rb = GetComponent<Rigidbody>();
        StartCoroutine(WaitToChangeDir());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(transform.right * speed * dir);
        transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0); 
	}
       
    IEnumerator WaitToChangeDir () {
        yield return new WaitForSeconds(dirChangeTime);
        ChangeDir();
    }

    void ChangeDir () {
        dir *= -1;
        transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - downDis, transform.localPosition.z); 
        StartCoroutine(WaitToChangeDir());
    }
}
