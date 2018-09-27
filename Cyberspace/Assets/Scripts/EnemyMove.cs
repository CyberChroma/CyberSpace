using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public enum State
    {
        enter,
        attack,
        exit
    }

    public float speed;
    public Transform[] path;
    public float stopTime;

    [HideInInspector] public State state;

    private int pathNum;
    private Vector3 offset;
    private Vector3 rotOffset;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        offset = rb.position - path[0].position;
        rotOffset = rb.rotation.eulerAngles - path[0].rotation.eulerAngles;
        pathNum = 1;
        state = State.enter;
        gameObject.SetActive(false);
	}

	// Update is called once per frame
	void FixedUpdate () {
        if (state == State.enter)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, path[pathNum].position + offset, speed / 10));
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, Quaternion.Euler(path[pathNum].rotation.eulerAngles + rotOffset), speed));
            if (Vector3.Distance(rb.position, path[pathNum].position + offset) <= 0.1f)
            {
                rb.MovePosition(path[pathNum].position + offset);
                rb.MoveRotation(Quaternion.Euler(path[pathNum].rotation.eulerAngles + rotOffset));
                pathNum++;
                if (path.Length <= pathNum)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        else if (state == State.attack)
        {
            transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 0);
        }
        else
        {
            transform.localPosition = (Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 5), speed / 10));
        }
	}

    void OnTriggerEnter (Collider other) {
        if (other.name == "Enemy Hit" && state == State.enter)
        {
            transform.parent = other.transform;
            state = State.attack;
            StartCoroutine (Attack());
        }
    }

    IEnumerator Attack () {
        yield return new WaitForSeconds(stopTime);
        state = State.exit;
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
