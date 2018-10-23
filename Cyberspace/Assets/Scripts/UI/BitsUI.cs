using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BitsUI : MonoBehaviour {

    public float moveSpeed = 2;

    public Color fullColor = Color.green; // The color of the slider when it is full
    public Color halfColor = Color.yellow; // The color of the slider when it is at half
    public Color emptyColor = Color.red; // The color of the slider when it is empty

    [HideInInspector] public int bits;
    [HideInInspector] public int reqBits;

    private bool sliderUpdating;
    private Image fillImage; // Reference to the fill image on the slider
    private Slider bitsSlider;
    private Text bitsText;

	// Use this for initialization
	void Start () {
        fillImage = transform.Find ("Fill Area/Fill").GetComponent<Image> (); // Getting the reference
        bitsText = GetComponentInChildren<Text>();
        bitsSlider = GetComponent<Slider>();
        bitsSlider.maxValue = reqBits;
        bitsText.text = "Bits: " + bits.ToString() + "/" + reqBits.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (sliderUpdating)
        {
            MoveSlider();
        }
	}

    public void AddBits (int points) {
        bits += points;
        if (bits < 0)
        {
            bits = 0;
        }
        bitsText.text = "Bits: " + bits.ToString() + "/" + reqBits.ToString();
        sliderUpdating = true;;
    }

    public void SetBits (int points) {
        bits = points;
        bitsText.text = "Bits: " + bits.ToString() + "/" + reqBits.ToString();
        sliderUpdating = true;
    }

    void MoveSlider () { // Moves the slider and sets the colors based on the value
        bitsSlider.value = Mathf.Lerp(bitsSlider.value, bits, moveSpeed * Time.deltaTime); // Setting the slider to match the current health
        if (bitsSlider.value > bitsSlider.maxValue / 2) { // If the value is over half
            fillImage.color = Color.Lerp (halfColor, fullColor, (bitsSlider.value - (bitsSlider.maxValue / 2)) / (bitsSlider.value / 2)); // Sets the color of the image
        } else { // If the value is under half
            fillImage.color = Color.Lerp (emptyColor, halfColor, bitsSlider.value / (bitsSlider.maxValue / 2)); // Sets the color of the image
        }
        if (bitsSlider.value == bits) { // If the value has reached the health
            sliderUpdating = false; // Setting the bool
        }
    }
}
