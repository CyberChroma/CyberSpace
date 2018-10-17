using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public float turnSpeed;
    public Transform gunPivot; // Reference to the gun's transform
    public float maxAngle;

    private float angle;
    private InputManager inputManager;

	// Use this for initialization
	void Start () {
        angle = 0;
        inputManager = FindObjectOfType<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inputManager.inputAR)
        {
            angle -= turnSpeed * 20 * Time.deltaTime;
        }
        else if (inputManager.inputAL)
        {
            angle += turnSpeed * 20 * Time.deltaTime;
        }
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
