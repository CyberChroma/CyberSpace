using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {
        
    public string levelName;
    public Material lockedMat;
    public int reqLightGears;
    public LevelInfo prevLevel;

    [HideInInspector] public bool locked;

    public int[] lightGears;
    public int levelBits;
    public string levelTime;

    private GameSaver gameSaver;

	// Use this for initialization
	void Awake () {

	}
	
    public void Initialize (int[] savedLightGears, int savedBits, string savedTime) {
        gameSaver = GameSaver.instance;
        lightGears = savedLightGears;
        levelBits = savedBits;
        levelTime = savedTime;
        if ((gameSaver.totalLightGears < reqLightGears) || (prevLevel != null && prevLevel.lightGears[0] == 0))
        {
            locked = true;
            GetComponent<MeshRenderer>().material = lockedMat;
        }
    }
}
