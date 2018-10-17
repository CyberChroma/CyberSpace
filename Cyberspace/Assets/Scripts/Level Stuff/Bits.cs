using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bits : MonoBehaviour {

    public int bits = 10;

    private BitsUI bitsUI;

	// Use this for initialization
	void Start () {
        bitsUI = GameObject.Find("Bits Text").GetComponent<BitsUI>();
	}

    void OnDisable () {
        if (bitsUI)
        {
            bitsUI.AddBits(bits);
        }
    }
}
