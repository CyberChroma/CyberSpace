using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipManager : MonoBehaviour {

    public Transform gunsParent;
    public Transform shipsParent;
    public Transform[] arrows;

    public GameObject[] guns;
    public GameObject[] ships;
    public int numGuns;
    public int numShips;

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
        shipsParent.localPosition = new Vector3(startPos.x - (gameSaver.activeShip - 1) * 3, startPos.y, startPos.z);
	}
	
	// Update is called once per frame
	void Update () {
        gunsParent.localPosition = Vector3.Lerp(gunsParent.localPosition, new Vector3(startPos.x - (gameSaver.activeGun - 1) * 3, startPos.y, startPos.z), moveSpeed * Time.deltaTime);
        shipsParent.localPosition = Vector3.Lerp(shipsParent.localPosition, new Vector3(startPos.x - (gameSaver.activeShip - 1) * 3, startPos.y, startPos.z), moveSpeed * Time.deltaTime);
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
                if (arrowOffset != 2)
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
            gameSaver.activeShip--;
            if (gameSaver.activeShip < 1)
            {
                gameSaver.activeShip = 1;
            }
            break;
        case 3:
            gameSaver.activeShip++;
            if (gameSaver.activeShip > numShips)
            {
                gameSaver.activeShip = numShips;
            }
            break;
        }
    }
}
