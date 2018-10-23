using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour {

    public float moveSpeed = 2;
    public Color fullColor = Color.red; // The color of the slider when it is full
    public Color halfColor = Color.yellow; // The color of the slider when it is at half
    public Color emptyColor = Color.green; // The color of the slider when it is empty

    [HideInInspector] public string reqTime;
    [HideInInspector] public Slider timeSlider;
    [HideInInspector] public Text timeText;
    [HideInInspector] public bool stop;

    private Image fillImage; // Reference to the fill image on the slider
    private float levelTime;
    private int sec;
    private int min;

	// Use this for initialization
	void Start () {
        fillImage = transform.Find ("Fill Area/Fill").GetComponent<Image> (); // Getting the reference
        timeText = GetComponentInChildren<Text>();
        timeSlider = GetComponent<Slider>();
        timeSlider.maxValue = int.Parse(reqTime.Substring(0, reqTime.IndexOf(':'))) * 60 + int.Parse(reqTime.Substring(reqTime.IndexOf(':')+1));
	}
	
	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            if (min < 99 && sec < 99)
            {
                levelTime += Time.deltaTime;
                if (levelTime > 1)
                {
                    sec++;
                    levelTime = 0;
                    if (sec >= 60)
                    {
                        min++;
                        sec = 0;
                    }
                }
                timeText.text = "Time: " + min.ToString() + ":" + sec.ToString("D2") + "/" + reqTime;
                MoveSlider();
            }
        }
	}

    void MoveSlider () { // Moves the slider and sets the colors based on the value
        timeSlider.value = Mathf.Lerp(timeSlider.value, min * 60 + sec, moveSpeed * Time.deltaTime); // Setting the slider to match the current health
        if (timeSlider.value > timeSlider.maxValue / 2) { // If the value is over half
            fillImage.color = Color.Lerp (halfColor, fullColor, (timeSlider.value - (timeSlider.maxValue / 2)) / (timeSlider.value / 2)); // Sets the color of the image
        } else { // If the value is under half
            fillImage.color = Color.Lerp (emptyColor, halfColor, timeSlider.value / (timeSlider.maxValue / 2)); // Sets the color of the image
        }
    }
}
