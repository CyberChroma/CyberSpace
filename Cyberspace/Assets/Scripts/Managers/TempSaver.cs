using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSaver : MonoBehaviour {

    public static TempSaver instance = null;

    public string activeCheckpointName;
    private Checkpoint activeCheckpoint;
    private Transform player;
    private Transform camPivot;

	// Use this for initialization
    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void NewScene () {
        player = GameObject.Find("Player").transform;
        camPivot = GameObject.Find("Camera Pivot").transform;
        if (activeCheckpointName != "")
        {
            activeCheckpoint = GameObject.Find(activeCheckpointName).GetComponent<Checkpoint>();
            player.position = activeCheckpoint.transform.position;
            player.rotation = activeCheckpoint.transform.rotation;
            camPivot.position = activeCheckpoint.transform.position;
            camPivot.rotation = activeCheckpoint.transform.rotation;
            activeCheckpoint.Respawn();
        }
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void Activate (string checkpoint) {
        activeCheckpointName = checkpoint;
    }
}
