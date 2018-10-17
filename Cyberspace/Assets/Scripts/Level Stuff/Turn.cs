using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

    public float turnSpeed = 2;
    public Vector3 startRot = Vector3.zero;
    public Vector3 endRot = Vector3.up * 90;

    private bool turned = false;
    private bool turning = false;
    private Move move;
    private Rigidbody playerRb;

	// Use this for initialization
	void Awake () {
        GameObject player = GameObject.Find("Player");
        move = player.GetComponent<Move>();
        playerRb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (turning)
        {
            if (turned)
            {
                playerRb.rotation = Quaternion.RotateTowards(playerRb.rotation, Quaternion.Euler(endRot), turnSpeed);
                if (Quaternion.Angle(playerRb.rotation, Quaternion.Euler(endRot)) < 0.1f)
                {
                    playerRb.transform.rotation = Quaternion.Euler(endRot);
                    move.enabled = true;
                    turning = false;
                }
            }
            else
            {
                playerRb.rotation = Quaternion.RotateTowards(playerRb.rotation, Quaternion.Euler(startRot), turnSpeed);
                if (Quaternion.Angle(playerRb.rotation, Quaternion.Euler(startRot)) < 0.1f)
                {
                    playerRb.transform.rotation = Quaternion.Euler(startRot);
                    move.enabled = true;
                    turning = false;
                }
            }
        }
	}

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player"))
        {
            turned = !turned;
            playerRb.velocity = Vector3.zero;
            playerRb.transform.position = new Vector3 (transform.position.x, playerRb.position.y, transform.position.z);
            move.enabled = false;
            if (turned)
            {
                playerRb.transform.rotation = Quaternion.Euler(startRot);
            }
            else
            {
               playerRb.transform.rotation = Quaternion.Euler(endRot);
            }
            turning = true;
        }
    }
}
