using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public GameObject mouseTracker;
    public Transform gun; // Reference to the gun's transform

    private Rigidbody rbGun; // Reference to the rigidbody component of the gun

	// Use this for initialization
	void Start () {
        rbGun = gun.GetComponent<Rigidbody> (); // Getting the reference
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8)) {
            if (hit.point.y <= 4) {
                hit.point = new Vector3 (hit.point.x, 4, rbGun.transform.position.z);
            } else {
                hit.point = new Vector3 (hit.point.x, hit.point.y, rbGun.transform.position.z);
            }

            rbGun.transform.LookAt (hit.point);
        }
        mouseTracker.transform.position = new Vector3 (rbGun.transform.position.x, mouseTracker.transform.position.y, rbGun.transform.position.z);
	}
}
