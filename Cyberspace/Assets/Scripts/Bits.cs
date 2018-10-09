using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bits : MonoBehaviour {

    public int bits;

    private BitsUI bitsUI;

	// Use this for initialization
	void Start () {
        bitsUI = GameObject.Find("Bits Text").GetComponent<BitsUI>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnDisable () {
        if (Time.timeSinceLevelLoad > 1)
        {
            bitsUI.AddBits(bits);
        }
    }
}
