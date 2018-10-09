using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float moveSpeed;

    public Material unselected;
    public Material selected;

    public Transform levelsParent;
    public float minBoundary;
    public float maxBoundary;
    public LevelInfo[] levels;

    private Vector3 startPos;
    private LevelInfo activeLevel;
    private LabCamera labCamera;

    public void Initialize (int[] lightGears, int[] scores) {
        startPos = levelsParent.localPosition;
        labCamera = FindObjectOfType<LabCamera>();
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i] != null)
            {
                levels[i].Initialize(lightGears[i], scores[i]);
            }
        }
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i] != null && levels[i].locked)
            {
                maxBoundary = levels[i].transform.localPosition.z + 0.1f;
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (labCamera.activePos == 5)
        {
            if (Input.GetKey(KeyCode.D))
            {
                levelsParent.localPosition = new Vector3(startPos.x, startPos.y, startPos.z + levelsParent.localPosition.z + -moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                levelsParent.localPosition = new Vector3(startPos.x, startPos.y, startPos.z + levelsParent.localPosition.z + moveSpeed * Time.deltaTime);
            }
            if (levelsParent.localPosition.z > minBoundary)
            {
                levelsParent.localPosition = new Vector3(startPos.x, startPos.y, startPos.z + minBoundary);
            }
            else if (levelsParent.localPosition.z < -maxBoundary)
            {
                levelsParent.localPosition = new Vector3(startPos.x, startPos.y, startPos.z + -maxBoundary);
            }
        }
	}

    public void ActivateLevel (LevelInfo levelInfo) {
        if (labCamera.activePos == 5)
        {
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
    }
}
