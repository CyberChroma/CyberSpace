using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private Animator anim;
    private RespawnManager respawnManager;

	// Use this for initialization
	void Awake () {
        respawnManager = FindObjectOfType<RespawnManager>();
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
            if (anim)
            {
                anim.SetTrigger("Activate");
            }
            respawnManager.ActivateCheckpoint (this);
        }
    }

    public void Respawn () {
        if (anim)
        {
            anim.SetTrigger("Respawn");
        }
    }
}
