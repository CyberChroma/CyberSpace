using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour {

    public string levelName;
    public int lightGears;
    public float score;
    public bool locked;

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
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
