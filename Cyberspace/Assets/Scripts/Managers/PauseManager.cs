using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public Text[] texts;

    private bool paused;
    private bool options;
    private int activeButton;
    private InputManager inputManager;

	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        inputManager = FindObjectOfType<InputManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (paused)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (activeButton != 0)
                {
                    texts[activeButton].fontStyle = FontStyle.Normal;
                    activeButton--;
                    texts[activeButton].fontStyle = FontStyle.Bold;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (activeButton != texts.Length - 1)
                {
                    texts[activeButton].fontStyle = FontStyle.Normal;
                    activeButton++;
                    texts[activeButton].fontStyle = FontStyle.Bold;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                switch (activeButton)
                {
                    case 0:
                        Resume();
                        break;
                    case 1:
                        Options();
                        break;
                    case 2:
                        Restart();
                        break;
                    case 3:
                        Quit();
                        break;
                }
            }
            else if (options && Input.GetKeyDown(KeyCode.LeftShift))
            {
                Back();
            }
        }
	}

    void Pause () {
        paused = true;
        pauseMenu.SetActive(true);
        inputManager.canMove = false;
        activeButton = 0;
        texts[activeButton].fontStyle = FontStyle.Bold;
        Time.timeScale = 0;
    }

    void Resume () {
        paused = false;
        pauseMenu.SetActive(false);
        inputManager.canMove = true;
        Time.timeScale = 1;
    }

    void Options () {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        options = true;
    }

    void Back () {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        options = false;
    }

    void Restart () {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Quit () {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lab");
    }
}
