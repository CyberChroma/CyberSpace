using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Image blackScreen;

    public GameObject[] guns;
    public GameObject[] ships;

    [HideInInspector] public bool fadeIn = true;
    private GameSaver gameSaver;
	// Use this for initialization
	void Awake () {
        blackScreen.gameObject.SetActive(true);
        gameSaver = GameSaver.instance;
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        foreach (GameObject ship in ships)
        {
            ship.SetActive(false);
        }
        guns[gameSaver.activeGun - 1].SetActive(true);
        ships[gameSaver.activeShip - 1].SetActive(true);
	}
	
	// Update is called once per frame
    void Update () {
        if (fadeIn && blackScreen.color != new Color(0, 0, 0, 0))
        {
            blackScreen.color = Color.Lerp(blackScreen.color, new Color(0, 0, 0, 0), 0.25f);
        } else if (!fadeIn && blackScreen.color != new Color(0, 0, 0, 1)) {
            blackScreen.color = Color.Lerp(blackScreen.color, new Color(0, 0, 0, 1), 0.25f);
        }
    }

    public void EndLevel () {
        fadeIn = false;
        StartCoroutine(WaitToEnd());
    }

    public void Restart () {
        fadeIn = false;
        StartCoroutine(WaitToRestart());
    }

    IEnumerator WaitToRestart () {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator WaitToEnd () {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Lab");
    }
}
