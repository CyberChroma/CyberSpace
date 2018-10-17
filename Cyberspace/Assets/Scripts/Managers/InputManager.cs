using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public KeyCode moveL = KeyCode.A;
    public KeyCode moveR = KeyCode.D;
    public KeyCode shoot = KeyCode.Space;
    public KeyCode aimL = KeyCode.J;
    public KeyCode aimR = KeyCode.L;

    [HideInInspector] public bool inputL = false;
    [HideInInspector] public bool inputR = false;
    [HideInInspector] public bool inputS = false;
    [HideInInspector] public bool inputAL = false;
    [HideInInspector] public bool inputAR = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inputL = Input.GetKey(moveL);
        inputR = Input.GetKey(moveR);
        inputS = Input.GetKeyDown(shoot);
        inputAL = Input.GetKey(aimL);
        inputAR = Input.GetKey(aimR);
	}
}
