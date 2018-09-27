using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartStats : MonoBehaviour {

    public float addedHealth;

    public float addedSpeed;
    public float slide;

    public GameObject shot;
    public float coolDown;

    public bool canAim;
    public float turnSpeed;
    public float maxAngle;

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
            moveLR.slide += slide;
            if (shot != null)
            {
                shoot.shot = shot;
            }
            coolDown += coolDown;
            if (canAim)
            {
                aim.enabled = true;
            }
            aim.turnSpeed += turnSpeed;
            aim.maxAngle += maxAngle;
        }
	}
}
