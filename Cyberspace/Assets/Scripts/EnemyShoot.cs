using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float shotTime;
    public GameObject shot;
    public Transform gun;

    private bool started;
    private bool canShoot;
    private Animator anim;
    private Transform shotParent;
    private EnemyMove enemyMove;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        shotParent = GameObject.Find("Shots").transform;
        enemyMove = GetComponent<EnemyMove>();
        canShoot = false;
        started = false;
	}

    void Update () {
        if (enemyMove) {
            if (enemyMove.state == EnemyMove.State.attack) {
                if (!started)
                {
                    StartCoroutine(WaitToShoot());
                }
                else if (canShoot)
                {
                    StartCoroutine(Shoot());
                }
            } else if (enemyMove.state == EnemyMove.State.exit) {
                enabled = false;
            }
        }
    }

    IEnumerator WaitToShoot () {
        started = true;
        yield return new WaitForSeconds(shotTime);
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot () {
        canShoot = false;
        anim.SetTrigger("Shoot");
        Instantiate(shot, gun.position, gun.rotation, shotParent);
        yield return new WaitForSeconds(shotTime);
        canShoot = true;
    }
}
