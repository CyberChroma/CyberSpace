using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float startHealth = 10;
    public string[] tagsToDamage = new string[1] {"Player Shot"};
    public float timeToDisable = 0;
    public bool destroy = false;
    public GameObject spawnExplosion;
    public GameObject deathExplosion;
    public GameObject parent;

    [HideInInspector] public bool healthChanged;
    [HideInInspector] public float currentHealth;

    private Transform particleParent;

	// Use this for initialization
	void Start () {
        particleParent = GameObject.Find("Particle Systems").transform;
	}
       
    void OnEnable () {
        healthChanged = true;
        currentHealth = startHealth;
        if (spawnExplosion && Time.timeSinceLevelLoad > 1)
        {
            Instantiate(spawnExplosion, transform.position, transform.rotation, particleParent);
        }
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
                    StartCoroutine(WaitToDestroy());
                }
            }
        }
    }

    IEnumerator WaitToDestroy () {
        yield return new WaitForSeconds(timeToDisable);
        if (destroy)
        {
            Destroy(parent);
        }
        else
        {
            parent.SetActive(false);
        }
    }
}
