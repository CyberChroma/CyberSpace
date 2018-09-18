using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    private int score;
    private Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore (int points) {
        score += points;
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score.ToString();
    }
}
