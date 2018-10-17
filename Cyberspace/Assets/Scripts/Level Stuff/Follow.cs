using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform target;
    public float smoothing;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, smoothing * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, smoothing * Time.deltaTime);
        }
	}
}
