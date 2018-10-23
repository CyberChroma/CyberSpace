using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public int reqBits;
    public string reqTime;

    public GameObject levelCompleteScreen;
    public GameObject bitsGear;
    public GameObject timeGear;

    private InputManager inputManager;
    private BitsUI bitsUI;
    private TimeUI timeUI;
    private GameManager gameManager;
    private GameSaver gameSaver;
    private int[] lightGearsEarned = new int[3];
    private bool levelCompleted;

	// Use this for initialization
	void Awake () {
        levelCompleteScreen.SetActive(false);
        inputManager = FindObjectOfType<InputManager>();
        gameManager = FindObjectOfType<GameManager>();
        gameSaver = GameSaver.instance;
        bitsUI = FindObjectOfType<BitsUI>();
        timeUI = FindObjectOfType<TimeUI>();
        bitsUI.reqBits = reqBits;
        timeUI.reqTime = reqTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (levelCompleted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameSaver.Record(lightGearsEarned, bitsUI.bits, timeUI.min.ToString() + ":" + timeUI.sec.ToString("D2"));
                gameManager.EndLevel();
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                gameSaver.Record(lightGearsEarned, bitsUI.bits, timeUI.min.ToString() + ":" + timeUI.sec.ToString("D2"));
                gameManager.Restart();
            }
        }
	}

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
            lightGearsEarned[0] = 1;
            inputManager.canMove = false;
            if (bitsUI.bits >= reqBits)
            {
                lightGearsEarned[1] = 1;
                bitsGear.SetActive(true);
            }
            timeUI.stop = true;
            if (timeUI.timeSlider.value < timeUI.timeSlider.maxValue)
            {
                lightGearsEarned[2] = 1;
                timeGear.SetActive(true);
            }
            levelCompleteScreen.SetActive(true);
            levelCompleted = true;
        }
    }
}
