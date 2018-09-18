using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform target;
    public float smoothing;
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.position, smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, smoothing);
	}
}
