using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    
    public float speed;
    public GameObject deathExplosion;

    private Transform particleParent;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        particleParent = GameObject.Find("Particle Systems").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
	}

    void OnDisable () {
        if (deathExplosion)
        {
            Instantiate(deathExplosion, transform.position, transform.rotation, particleParent);
        }
    }
}
