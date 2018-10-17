using System.Collections;
using System.Collections.Generic;

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

    private Vector3 startPos;
    private GameSaver gameSaver;
    private LabCamera labCamera;

	// Use this for initialization
	void Start () {
        gameSaver = FindObjectOfType<GameSaver>();
        labCamera = FindObjectOfType<LabCamera>();
        startPos = transform.localPosition;
        gunsParent.localPosition = new Vector3(startPos.x - (gameSaver.activeGun - 1) * 3, startPos.y, startPos.z);
        centersParent.localPosition = new Vector3(startPos.x - (gameSaver.activeCenter - 1) * 3, startPos.y, startPos.z);
        wheelsParent.localPosition = new Vector3(startPos.x - (gameSaver.activeWheel - 1) * 3, startPos.y, startPos.z);
	}
	
	// Update is called once per frame
	void Update () {
        gunsParent.localPosition = Vector3.Lerp(gunsParent.localPosition, new Vector3(startPos.x - (gameSaver.activeGun - 1) * 3, startPos.y, startPos.z), moveSpeed * Time.deltaTime);
        centersParent.localPosition = Vector3.Lerp(centersParent.localPosition, new Vector3(startPos.x - (gameSaver.activeCenter - 1) * 3, startPos.y, startPos.z), moveSpeed * Time.deltaTime);
        wheelsParent.localPosition = Vector3.Lerp(wheelsParent.localPosition, new Vector3(startPos.x - (gameSaver.activeWheel - 1) * 3, startPos.y, startPos.z), moveSpeed * Time.deltaTime);
    }

    public void Move (int arrow) {
        if (labCamera.activePos == 3)
        {
            switch (arrow)
            {
                case 0:
                    gameSaver.activeGun--;
                    if (gameSaver.activeGun < 1)
                    {
                        gameSaver.activeGun = 1;
                    }
                    break;
                case 1:
                    gameSaver.activeGun++;
                    if (gameSaver.activeGun > numGuns)
                    {
                        gameSaver.activeGun = numGuns;
                    }
                    break;
                case 2:
                    gameSaver.activeCenter--;
                    if (gameSaver.activeCenter < 1)
                    {
                        gameSaver.activeCenter = 1;
                    }
                    break;
                case 3:
                    gameSaver.activeCenter++;
                    if (gameSaver.activeCenter > numCenters)
                    {
                        gameSaver.activeCenter = numCenters;
                    }
                    break;
                case 4:
                    gameSaver.activeWheel--;
                    if (gameSaver.activeWheel < 1)
                    {
                        gameSaver.activeWheel = 1;
                    }
                    break;
                case 5:
                    gameSaver.activeWheel++;
                    if (gameSaver.activeWheel > numWheels)
                    {
                        gameSaver.activeWheel = numWheels;
                    }
                    break;
            }
        }
    }
}
