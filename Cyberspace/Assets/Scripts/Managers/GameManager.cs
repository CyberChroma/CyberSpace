using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float fadeInSpeed = 0.5f;
    public Image blackScreen;

    public GameObject[] guns;
    public GameObject[] centers;
    public GameObject[] wheels;

    private bool fadeIn = true;

	// Use this for initialization
	void Awake () {
        blackScreen.gameObject.SetActive(true);
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        foreach (GameObject center in centers)
        {
            center.SetActive(false);
        }
        foreach (GameObject wheel in wheels)
        {
            wheel.SetActive(false);
        }
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            guns[data.gun - 1].SetActive(true);
            centers[data.center - 1].SetActive(true);
            wheels[data.wheel - 1].SetActive(true);
            file.Close();
        }
        else
        {
            guns[0].SetActive(true);
            centers[0].SetActive(true);
            wheels[0].SetActive(true);
        }
	}
	
	// Update is called once per frame
    void Update () {
        if (fadeIn && blackScreen.color != new Color(0, 0, 0, 0))
        {
            blackScreen.color = Color.Lerp(blackScreen.color, new Color(0, 0, 0, 0), fadeInSpeed);
        } else if (!fadeIn && blackScreen.color != new Color(0, 0, 0, 1)) {
            blackScreen.color = Color.Lerp(blackScreen.color, new Color(0, 0, 0, 1), fadeInSpeed);
        }
    }

    public void EndLevel () {
        fadeIn = false;
        StartCoroutine(WaitToEnd());
    }

    IEnumerator WaitToEnd () {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Lab");
    }
}
