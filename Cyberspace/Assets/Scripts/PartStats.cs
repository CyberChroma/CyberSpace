using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartStats : MonoBehaviour {

    public float addedHealth;

    public float addedSpeed;

    public GameObject shot;
    public float coolDown;

    public bool canAim;

    private Health health;
    private MoveLR moveLR;
    private Shoot shoot;
    private Aim aim;

	// Use this for initialization
	void Awake () {
        if (gameObject.activeSelf)
        {
            health = GetComponentInParent<Health>();
            moveLR = GetComponentInParent<MoveLR>();
            shoot = GetComponentInParent<Shoot>();
            aim = GetComponentInParent<Aim>();
            health.startHealth += addedHealth;
            moveLR.speed += addedSpeed;
            if (shot != null)
            {
                shoot.shot = shot;
            }
            coolDown += coolDown;
            if (canAim)
            {
                aim.enabled = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
