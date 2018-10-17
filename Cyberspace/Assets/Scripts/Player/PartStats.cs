using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartStats : MonoBehaviour {

    public float addedHealth;

    public float speed;
    public float weight;

    public GameObject shot;
    public float coolDown;

    public bool canAim;
    public float turnSpeed;

    private Health health;
    private Move move;
    private Shoot shoot;
    private Aim aim;

	// Use this for initialization
	void Start () {
        if (gameObject.activeSelf && GameObject.Find("Player"))
        {
            health = GetComponentInParent<Health>();
            move = GetComponentInParent<Move>();
            shoot = GetComponentInParent<Shoot>();
            aim = GetComponentInParent<Aim>();
            health.startHealth += addedHealth;
            move.speed += speed;
            move.weight += weight;
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
        }
	}
}
