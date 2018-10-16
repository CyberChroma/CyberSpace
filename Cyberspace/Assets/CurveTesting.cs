using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveTesting : MonoBehaviour {

    public BezierCurve path;
    public float speed;

    private float perc = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (speed > 0)
        {
            while (perc < 1)
            {
                perc += 0.01f;
                Debug.DrawRay(path.GetPointAt(perc), Vector3.up * 2, Color.red);
            }
            perc = 0;
        }
	}
}
