using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public MeshRenderer[] texts;
    public Material activeMat;
    public Material unactiveMat;

    private int activeButton;
    private GameSaver gameSaver;

	// Use this for initialization
	void Start () {
        gameSaver = GameSaver.instance;
        texts[activeButton].material = activeMat;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (activeButton != 0)
            {
                texts[activeButton].material = unactiveMat;
                activeButton--;
                texts[activeButton].material = activeMat;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (activeButton != texts.Length - 1)
            {
                texts[activeButton].material = unactiveMat;
                activeButton++;
                texts[activeButton].material = activeMat;
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
