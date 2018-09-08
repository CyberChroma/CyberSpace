using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float startHealth;
    public string[] tagsToDamage;
    public GameObject deathExplosion;

    [HideInInspector] public bool healthChanged;
    [HideInInspector] public float currentHealth;

    private Transform particleParent;

	// Use this for initialization
	void Start () {
        healthChanged = true;
        currentHealth = startHealth;
        particleParent = GameObject.Find("Particle Systems").transform;
	}

    void OnTriggerEnter (Collider other) {
        foreach (string tag in tagsToDamage)
        {
            if (other.CompareTag(tag))
            {
                currentHealth--;
                healthChanged = true;
                if (currentHealth <= 0)
                {
                    if (deathExplosion)
                    {
                        Instantiate(deathExplosion, transform.position, transform.rotation, particleParent);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
