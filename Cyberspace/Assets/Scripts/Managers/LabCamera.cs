using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabCamera : MonoBehaviour {

    public float smoothing;
    public Transform[] camPositions; // middle, mainMenu, customAir, customLand, levelCreator, levelSelect, options

    [HideInInspector] public int activePos;
    private int turnDir;
    private GameSaver gameSaver;

	// Use this for initialization
	void Start () {
        transform.position = camPositions[1].position;
        transform.rotation = camPositions[1].rotation;
        activePos = 0;
        turnDir = 1;
        gameSaver = FindObjectOfType<GameSaver>();
	}

	// Update is called once per frame
	void Update () {
        if (activePos == 0) {
            if (Input.GetKeyDown(KeyCode.D))
            {
                camPositions[0].rotation = Quaternion.Euler(new Vector3(5, camPositions[0].rotation.eulerAngles.y + 60, 0));
                turnDir += 1;
                if (turnDir > 6)
                {
                    turnDir = 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                camPositions[0].rotation = Quaternion.Euler(new Vector3(5, camPositions[0].rotation.eulerAngles.y - 60, 0));
                turnDir -= 1;
                if (turnDir < 1)
                {
                    turnDir = 6;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                activePos = turnDir;
                gameSaver.Save();
            }
        } else if (Input.GetKeyDown(KeyCode.LeftShift)) {
            activePos = 0;
        }
        transform.position = Vector3.Lerp(transform.position, camPositions[activePos].position, smoothing * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, camPositions[activePos].rotation, smoothing * Time.deltaTime);
	}
}
