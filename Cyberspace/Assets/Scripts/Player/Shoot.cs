using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject shot;
    public Transform gun;
    public float cooldown;

    private bool canShoot = true;
    private Transform shotParent;
    private InputManager inputManager;

	// Use this for initialization
	void Start () {
        shotParent = GameObject.Find("Shots").transform;
        inputManager = FindObjectOfType<InputManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (inputManager.inputS && canShoot)
        {
            Instantiate(shot, gun.position, gun.rotation, shotParent);
            StartCoroutine(WaitToShoot());
        }
	}

    IEnumerator WaitToShoot () {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
}
