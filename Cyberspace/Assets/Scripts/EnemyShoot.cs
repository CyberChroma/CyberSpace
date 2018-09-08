using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float shotTime;
    public float rand;
    public GameObject shot;
    public Transform gun;

    private Animator anim;
    private Transform shotParent;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        shotParent = GameObject.Find("Shots").transform;
        StartCoroutine(WaitToShoot());
	}

    IEnumerator WaitToShoot () {
        yield return new WaitForSeconds(shotTime + Random.Range(-rand, rand));
        Shoot();
    }

    void Shoot () {
        anim.SetTrigger("Shoot");
        Instantiate(shot, gun.position, gun.rotation, shotParent);
        StartCoroutine(WaitToShoot());
    }
}
