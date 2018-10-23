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

    private Vector3 startPos;
    private int activeLevel;
    private LabCamera labCamera;

    public void Initialize (int level, int[][] lightGears, int[] levelBits, string[] levelTimes) {
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
    }

    public void Activate () {
        levels[activeLevel].GetComponent<MeshRenderer>().material = selected;
    }
	
    public void Deactivate () {
        levels[activeLevel].GetComponent<MeshRenderer>().material = unselected;
    }

	// Update is called once per frame
	void Update () {
        if (labCamera.activePos == 5)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (activeLevel != 0)
                {
                    levels[activeLevel].GetComponent<MeshRenderer>().material = unselected;
                    activeLevel--;
                    levels[activeLevel].GetComponent<MeshRenderer>().material = selected;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (activeLevel != levels.Length - 1 && !levels[activeLevel + 1].locked)
                {
                    levels[activeLevel].GetComponent<MeshRenderer>().material = unselected;
                    activeLevel++;
                    levels[activeLevel].GetComponent<MeshRenderer>().material = selected;
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
