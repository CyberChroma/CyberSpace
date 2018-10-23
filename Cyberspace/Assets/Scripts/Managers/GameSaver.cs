using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaver : MonoBehaviour {

    public static GameSaver instance = null;

    [HideInInspector] public int[][] lightGears = new int[60][]; // Each item is a set of up to 3 light gears
    [HideInInspector] public int[] levelBits = new int[60];
    [HideInInspector] public string[] levelTimes = new string[60];
    [HideInInspector] public int bits = 0;
    [HideInInspector] public int totalLightGears = 0;
    [HideInInspector] public int activeGun = 1;
    [HideInInspector] public int activeCenter = 1;
    [HideInInspector] public int activeWheel = 1;

    [HideInInspector] public int level = 0;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
            for (int i = 0; i < lightGears.Length; i++)
            {
                lightGears[i] = new int[3];
            }
            if (SceneManager.GetActiveScene().name != "Main Menu")
            {
                Load();
            }
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        instance.NewScene();
        DontDestroyOnLoad(this.gameObject);
	}
       
    void NewScene () {
        if (FindObjectOfType<LevelManager>())
        {
            FindObjectOfType<LevelManager>().Initialize(level, lightGears, levelBits, levelTimes);
        }
    }

    public void New () {
        lightGears = new int[60][]; // Each item is a set of up to 3 light gears
        for (int i = 0; i < lightGears.Length; i++)
        {
            lightGears[i] = new int[3];
        }
        levelBits = new int[60];
        levelTimes = new string[60];
        bits = 0;
        totalLightGears = 0;
        activeGun = 1;
        activeCenter = 1;
        activeWheel = 1;
        Save();
    }

    public void Save () {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
        SaveData data = new SaveData();
        data.lightGears = lightGears;
        data.levelBits = levelBits;
        data.levelTimes = levelTimes;
        data.bits = bits;
        data.gun = activeGun;
        data.center = activeCenter;
        data.wheel = activeWheel;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load () {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            if (data.lightGears[0] == null)
            {
                for (int i = 0; i < data.lightGears.Length; i++)
                {
                    data.lightGears[i] = new int[3];
                }
            }
            lightGears = data.lightGears;
            levelBits = data.levelBits;
            levelTimes = data.levelTimes;
            bits = data.bits;
            activeGun = data.gun;
            activeCenter = data.center;
            activeWheel = data.wheel;
            file.Close();
            foreach (int[] lightGearSet in lightGears)
            {
                foreach (int lightGear in lightGearSet) {
                    totalLightGears += lightGear;
                }
            }
        }
    }

    public void Record (int[] lightGearsEarned, int bitsEarned, string time) {
        if (lightGears[level][0] != 1)
        {
            lightGears[level][0] = lightGearsEarned[0];
        }
        if (lightGears[level][1] != 1)
        {
            lightGears[level][1] = lightGearsEarned[1];
        }
        if (lightGears[level][2] != 2)
        {
            lightGears[level][2] = lightGearsEarned[2];
        }
        if (levelBits[level] < bitsEarned)
        {
            levelBits[level] = bitsEarned;
        }
        int savedLevelTime = int.Parse(levelTimes[level].Substring(0, levelTimes[level].IndexOf(":"))) * 60 + int.Parse(levelTimes[level].Substring(levelTimes[level].IndexOf(":")));
        int newLevelTime = int.Parse(time.Substring(0, time.IndexOf(":"))) * 60 + int.Parse(time.Substring(time.IndexOf(":")+1));
        if (savedLevelTime > newLevelTime)
        {
            levelTimes[level] = time;
        }
        bits += bitsEarned;
        Save();
    }
}

[System.Serializable]
class SaveData {
    public int[][] lightGears = new int[60][]; // Each item is a set of up to 3 light gears
    public int[] levelBits = new int[60];
    public string[] levelTimes = new string[60];
    public int bits = 0;
    public int gun = 1;
    public int center = 1;
    public int wheel = 1;
}
