using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public float turnSpeed;
    public Transform gunPivot; // Reference to the gun's transform
    public float maxAngle;

    private float angle;
    private float mouseAngle;

	// Use this for initialization
	void Start () {
        angle = 0;
        mouseAngle = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 9))
        {
            mouseAngle = Vector3.SignedAngle(transform.up, hit.point - transform.position, transform.forward);
        }
        angle = Mathf.MoveTowards(angle, mouseAngle, turnSpeed * 50 * Time.deltaTime);
        if (Mathf.Abs(angle) > maxAngle)
        {
            if (angle > 0)
            {
                angle = maxAngle;
            }
            else
            {
                angle = -maxAngle;
            }
        }
        gunPivot.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
