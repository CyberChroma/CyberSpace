using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipManager : MonoBehaviour {

    public Transform gunsParent;
    public Transform centersParent;
    public Transform wheelsParent;
    public Transform[] arrows;

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
    private int arrowOffset = 0;

	// Use this for initialization
	void Start () {
        gameSaver = GameSaver.instance;
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
        if (labCamera.activePos == 3)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(arrowOffset);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Move(arrowOffset + 1);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (arrowOffset != 0)
                {
                    arrowOffset -= 2;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (arrowOffset != 4)
                {
                    arrowOffset += 2;
                }
            }
            for (int i = 0; i < arrows.Length; i++)
            {
                if (i == arrowOffset / 2)
                {
                    arrows[i].localPosition = Vector3.Lerp(arrows[i].localPosition, new Vector3(arrows[i].localPosition.x, arrows[i].localPosition.y, -0.75f), moveSpeed * Time.deltaTime);
                }
                else
                {
                    arrows[i].localPosition = Vector3.Lerp(arrows[i].localPosition, new Vector3(arrows[i].localPosition.x, arrows[i].localPosition.y, -0.5f), moveSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].localPosition = Vector3.Lerp(arrows[i].localPosition, new Vector3(arrows[i].localPosition.x, arrows[i].localPosition.y, -0.5f), moveSpeed * Time.deltaTime);
            }
        }
    }

    public void Move (int arrow) {
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
