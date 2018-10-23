using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabCamera : MonoBehaviour {

    public float smoothing;
    public Transform[] camPositions; // middle, mainMenu, customAir, customLand, levelCreator, levelSelect, options

    [HideInInspector] public int activePos;
    private int turnDir;
    private GameSaver gameSaver;
    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        transform.position = camPositions[1].position;
        transform.rotation = camPositions[1].rotation;
        activePos = 0;
        turnDir = 1;
        gameSaver = GameSaver.instance;
        levelManager = FindObjectOfType<LevelManager>();
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
                if (activePos == 5)
                {
                    levelManager.Activate();
                }
                if (activePos == 1)
                {
                    StartCoroutine(MainMenu());
                }
            }
        } else if (Input.GetKeyDown(KeyCode.LeftShift)) {
            if (activePos == 5)
            {
                levelManager.Deactivate();
            }
            activePos = 0;
            gameSaver.Save();
        }
        transform.position = Vector3.Lerp(transform.position, camPositions[activePos].position, smoothing * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, camPositions[activePos].rotation, smoothing * Time.deltaTime);
	}

    IEnumerator MainMenu () {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main Menu");
    }
}
