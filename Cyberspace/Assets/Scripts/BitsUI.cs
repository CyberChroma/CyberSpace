using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BitsUI : MonoBehaviour {

    private int bits;
    private Text bitsText;

	// Use this for initialization
	void Start () {
        bitsText = GetComponent<Text>();
        bitsText.text = "Bits: " + bits.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBits (int points) {
        bits += points;
        if (bits < 0)
        {
            bits = 0;
        }
        bitsText.text = "Bits: " + bits.ToString();
    }
}
