using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {
        
    public string levelName;
    public int lightGears;
    public float score;
    public Material lockedMat;
    public int reqLightGears;
    public LevelInfo prevLevel;

    [HideInInspector] public bool locked;
    private LevelManager levelManager;
    private GameSaver gameSaver;

	// Use this for initialization
	public void Awake () {

	}
	
    public void Initialize (int savedLightGears, int savedScore) {
        levelManager = FindObjectOfType<LevelManager>();
        gameSaver = FindObjectOfType<GameSaver>();
        lightGears = savedLightGears;
        score = savedScore;
        if ((gameSaver.totalLightGears < reqLightGears) || (prevLevel != null && prevLevel.lightGears == 0))
        {
            locked = true;
            GetComponent<MeshRenderer>().material = lockedMat;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0) && !locked)
        {
            levelManager.ActivateLevel(this);
        }
    }
}
