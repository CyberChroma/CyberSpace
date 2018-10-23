using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour {

    public float turnSpeed = 1;
    public float maxAngle= 60;
    public Vector3 startDir = Vector3.forward;
    public Transform pivot;

    private Vector3 dir;
    private Quaternion startRot;

	// Use this for initialization
	void Start () {
        startRot = pivot.rotation;
	}

    void OnEnable () {
        dir = startDir;
    }

    void OnDisable () {
        pivot.rotation = startRot;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        pivot.rotation = pivot.rotation * Quaternion.Euler(dir * turnSpeed);
        if (Quaternion.Angle(startRot, pivot.rotation) > maxAngle) {
            dir *= -1;
        }
	}
}
