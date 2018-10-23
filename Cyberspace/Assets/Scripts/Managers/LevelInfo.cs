using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {
        
    public string levelName;
    public Material lockedMat;
    public int reqLightGears;
    public LevelInfo prevLevel;
    public Material aquiredMat;

    [HideInInspector] public bool locked;

    public int[] lightGears;
    public int levelBits;
    public string levelTime;

    private GameSaver gameSaver;
	
    public void Initialize (int[] savedLightGears, int savedBits, string savedTime) {
        gameSaver = GameSaver.instance;
        lightGears = savedLightGears;
        levelBits = savedBits;
        levelTime = savedTime;
        if (lightGears[0] == 1)
        {
            transform.Find("Complete Gear").GetComponent<MeshRenderer>().material = aquiredMat;
        }
        if (lightGears[1] == 1)
        {
            transform.Find("Bits Gear").GetComponent<MeshRenderer>().material = aquiredMat;
        }
        if (lightGears[2] == 1)
        {
            transform.Find("Time Gear").GetComponent<MeshRenderer>().material = aquiredMat;
        }
        if ((gameSaver.totalLightGears < reqLightGears) || (prevLevel != null && prevLevel.lightGears[0] == 0))
        {
            locked = true;
            GetComponent<MeshRenderer>().material = lockedMat;
        }
    }
}
