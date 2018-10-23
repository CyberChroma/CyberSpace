using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Text[] texts;

    private int activeButton;
    private GameSaver gameSaver;

	// Use this for initialization
	void Start () {
        gameSaver = GameSaver.instance;
        texts[activeButton].fontStyle = FontStyle.Bold;
	}
	
	// Update is called once per frame
	void Update () {
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
                    NewGame();
                    break;
                case 1:
                    Continue();
                    break;
                case 2:
                    Quit();
                    break;
            }
        }
	}

    void NewGame () {
        gameSaver.New();
        SceneManager.LoadScene("Lab");
    }

    void Continue () {
        gameSaver.Load();
        SceneManager.LoadScene("Lab");
    }

    void Quit () {
        gameSaver.Save();
        Application.Quit();
    }
}
