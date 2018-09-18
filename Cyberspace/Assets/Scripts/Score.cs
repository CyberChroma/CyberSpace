using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score;

    private ScoreUI scoreUI;

	// Use this for initialization
	void Start () {
        scoreUI = GameObject.Find("Score Text").GetComponent<ScoreUI>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnDisable () {
        if (Time.timeSinceLevelLoad > 1)
        {
            scoreUI.AddScore(score);
        }
    }
}
