using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float moveSpeed;

    public Material unselected;
    public Material selected;

    public Transform levelsParent;
    public LevelInfo[] levels;
    public GameObject[] totalGears1sColumn;
    public GameObject[] totalGears10sColumn;
    public GameObject[] totalGears100sColumn;

    private Vector3 startPos;
    private int activeLevel;
    private LabCamera labCamera;

    public void Initialize (int level, int[][] lightGears, int[] levelBits, string[] levelTimes, int totalLightGears) {
        startPos = levelsParent.localPosition;
        labCamera = FindObjectOfType<LabCamera>();
        activeLevel = level;
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i] != null)
            {
                levels[i].Initialize(lightGears[i], levelBits[i], levelTimes[i]);
            }
        }
        int tempLightGears = totalLightGears;
        if (totalLightGears >= 100)
        {
            totalGears100sColumn[0].SetActive(false);
            totalGears100sColumn[totalLightGears / 100].SetActive(true);
            tempLightGears -= 100;
        }
        if (tempLightGears >= 10)
        {
            totalGears10sColumn[0].SetActive(false);
            totalGears10sColumn[tempLightGears / 10].SetActive(true);
            tempLightGears -= 10;
        }
        if (tempLightGears >= 1)
        {
            totalGears1sColumn[0].SetActive(false);
            totalGears1sColumn[tempLightGears].SetActive(true);
        }
    }

    public void Activate () {
        levels[activeLevel].transform.Find("Level Node").Find("Level_Node").GetComponent<MeshRenderer>().material = selected;
    }
	
    public void Deactivate () {
        levels[activeLevel].transform.Find("Level Node").Find("Level_Node").GetComponent<MeshRenderer>().material = unselected;
    }

	// Update is called once per frame
	void Update () {
        if (labCamera.activePos == 5)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (activeLevel != 0)
                {
                    levels[activeLevel].transform.Find("Level Node").Find("Level_Node").GetComponent<MeshRenderer>().material = unselected;
                    activeLevel--;
                    levels[activeLevel].transform.Find("Level Node").Find("Level_Node").GetComponent<MeshRenderer>().material = selected;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (activeLevel != levels.Length - 1 && !levels[activeLevel + 1].locked)
                {
                    levels[activeLevel].transform.Find("Level Node").Find("Level_Node").GetComponent<MeshRenderer>().material = unselected;
                    activeLevel++;
                    levels[activeLevel].transform.Find("Level Node").Find("Level_Node").GetComponent<MeshRenderer>().material = selected;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                GameSaver.instance.level = activeLevel;
                SceneManager.LoadScene(levels[activeLevel].levelName);
            }
        }
        levelsParent.localPosition = Vector3.Lerp(levelsParent.localPosition, new Vector3(startPos.x, startPos.y, startPos.z + -levels[activeLevel].transform.localPosition.z), moveSpeed * Time.deltaTime);
	}
}
