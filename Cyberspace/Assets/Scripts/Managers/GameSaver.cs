using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class GameSaver : MonoBehaviour {

    public static GameSaver instance = null;

    [HideInInspector] public int[] lightGears = new int[60]; // Each item is a set of up to 3 light gears
    [HideInInspector] public int bits = 0;
    [HideInInspector] public int[] scores = new int[60];
    [HideInInspector] public int totalLightGears;
    [HideInInspector] public int activeGun = 1;
    [HideInInspector] public int activeCenter = 1;
    [HideInInspector] public int activeWheel = 1;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        instance.NewScene();
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
       
    void NewScene () {
        Load();
        if (FindObjectOfType<LevelManager>())
        {
            FindObjectOfType<LevelManager>().Initialize(lightGears, scores);
        }
    }

    public void Save () {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        SaveData data = new SaveData();
        data.gun = activeGun;
        data.center = activeCenter;
        data.wheel = activeWheel;
        bf.Serialize(file, data);
        file.Close();
    }

    void Load () {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            activeGun = data.gun;
            activeCenter = data.center;
            activeWheel = data.wheel;
            file.Close();
            foreach (int lightGear in lightGears)
            {
                totalLightGears += lightGear;
            }
        }
    }
}

[System.Serializable]
class SaveData {
    public int[] lightGears = new int[60]; // Each item is a set of up to 3 light gears
    public int bits = 0;
    public int[] scores = new int[60];

    public int gun = 1;
    public int center = 1;
    public int wheel = 1;
}
