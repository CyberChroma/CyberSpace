using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject optionsMenu;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
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
	}

    void Pause () {
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume () {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options () {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back () {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Restart () {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit () {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level Select");
    }
}
