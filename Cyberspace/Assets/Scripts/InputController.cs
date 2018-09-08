using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public KeyCode moveL = KeyCode.A;
    public KeyCode moveR = KeyCode.D;
    public KeyCode shoot = KeyCode.Space;

    [HideInInspector] public bool inputL = false;
    [HideInInspector] public bool inputR = false;
    [HideInInspector] public bool inputS = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inputL = Input.GetKey(moveL);
        inputR = Input.GetKey(moveR);
        inputS = Input.GetKeyDown(shoot);

	}
}
