using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float shotTime = 1;
    public float rand = 0.5f;
    public GameObject shot;
    public Transform gun;

    private bool canShoot;
    private Animator anim;
    private Transform shotParent;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        shotParent = GameObject.Find("Shots").transform;
        canShoot = false;
        StartCoroutine(Shoot());
	}

    void Update () {
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot () {
        canShoot = false;
        if (anim)
        {
            anim.SetTrigger("Shoot");
        }
        Instantiate(shot, gun.position, gun.rotation, shotParent);
        yield return new WaitForSeconds(shotTime + Random.Range(-rand, rand));
        canShoot = true;
    }
}
