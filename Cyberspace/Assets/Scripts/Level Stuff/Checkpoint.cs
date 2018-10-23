using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private Animator anim;
    private RespawnManager respawnManager;
    private bool activated;

	// Use this for initialization
	void Awake () {
        respawnManager = FindObjectOfType<RespawnManager>();
        anim = GetComponentInChildren<Animator>();
	}

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player") && !activated)
        {
            if (anim)
            {
                anim.SetTrigger("Activate");
            }
            activated = true;
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
