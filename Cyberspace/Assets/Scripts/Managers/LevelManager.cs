using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float moveSpeed;
    public Material unselected;
    public Material selected;
    public Transform mCam;
    public float minBoundary;
    public float maxBoundary;

    private LevelInfo activeLevel;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.mousePosition.x < Screen.width / 8)
        {
            mCam.position = new Vector3(mCam.position.x + -moveSpeed * Time.deltaTime, 10, -1);
        }
        else if (Input.mousePosition.x > Screen.width - (Screen.width / 8))
        {
            mCam.transform.position = new Vector3(mCam.position.x + moveSpeed * Time.deltaTime, 10, -1);
        }
        if (mCam.position.x < minBoundary)
        {
            mCam.position = new Vector3(minBoundary, 10, -1);
        }
        else if (mCam.position.x > maxBoundary)
        {
            mCam.position = new Vector3(maxBoundary, 10, -1);
        }
	}

    public void ActivateLevel (LevelInfo levelInfo) {
        if (activeLevel == levelInfo)
        {
            SceneManager.LoadScene(activeLevel.levelName);
        }
        else
        {
            if (activeLevel)
            {
                activeLevel.GetComponent<MeshRenderer>().material = unselected;
            }
            activeLevel = levelInfo;
            activeLevel.GetComponent<MeshRenderer>().material = selected;
        }
    }

    public void Customize () {
        SceneManager.LoadScene("Customize");
    }
}
