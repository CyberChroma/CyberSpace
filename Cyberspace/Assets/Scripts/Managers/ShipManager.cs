using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipManager : MonoBehaviour {

    public Transform gunsParent;
    public Transform centersParent;
    public Transform wheelsParent;

    public GameObject[] guns;
    public GameObject[] centers;
    public GameObject[] wheels;

    public int numGuns;
    public int numCenters;
    public int numWheels;

    public float moveSpeed;

    private int activeGun = 1;
    private int activeCenter = 1;
    private int activeWheel = 1;

	// Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            activeGun = data.gun;
            activeCenter = data.center;
            activeWheel = data.wheel;
            file.Close();
            gunsParent.position = new Vector3((activeGun - 1) * -3, 0, 0);
            centersParent.position = new Vector3((activeCenter - 1) * -3, 0, 0);
            wheelsParent.position = new Vector3((activeWheel - 1) * -3, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        gunsParent.position = Vector3.Lerp(gunsParent.position, new Vector3((activeGun - 1) * -3, 0, 0), moveSpeed * Time.deltaTime);
        centersParent.position = Vector3.Lerp(centersParent.position, new Vector3((activeCenter - 1) * -3, 0, 0), moveSpeed * Time.deltaTime);
        wheelsParent.position = Vector3.Lerp(wheelsParent.position, new Vector3((activeWheel - 1) * -3, 0, 0), moveSpeed * Time.deltaTime);
	}

    public void Move (int arrow) {
        switch (arrow)
        {
            case 0:
                activeGun--;
                if (activeGun < 1)
                {
                    activeGun = 1;
                }
                break;
            case 1:
                activeGun++;
                if (activeGun > numGuns)
                {
                    activeGun = numGuns;
                }
                break;
            case 2:
                activeCenter--;
                if (activeCenter < 1)
                {
                    activeCenter = 1;
                }
                break;
            case 3:
                activeCenter++;
                if (activeCenter > numCenters)
                {
                    activeCenter = numCenters;
                }
                break;
            case 4:
                activeWheel--;
                if (activeWheel < 1)
                {
                    activeWheel = 1;
                }
                break;
            case 5:
                activeWheel++;
                if (activeWheel > numWheels)
                {
                    activeWheel = numWheels;
                }
                break;
        }
    }

    public void Back () {
        Save();
        SceneManager.LoadScene("Level Select");
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
}

[System.Serializable]
class SaveData {
    public int gun;
    public int center;
    public int wheel;
}
