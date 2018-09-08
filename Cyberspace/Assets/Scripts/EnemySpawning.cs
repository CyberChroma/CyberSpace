using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    public float spawnTime;
    public float rand;
    public int numToSpawn;
    public GameObject enemy;

    private int numSpawned;
    private Transform enemyParent;

	// Use this for initialization
	void Start () {
        numSpawned = 0;
        enemyParent = GameObject.Find("Enemies").transform;
        StartCoroutine(WaitToSpawn());
	}

    IEnumerator WaitToSpawn () {
        yield return new WaitForSeconds(spawnTime + Random.Range(-rand, rand));
        Spawn();
    }

    void Spawn () {
        Instantiate(enemy, transform.position, transform.rotation, enemyParent);
        StartCoroutine(WaitToSpawn());
        numSpawned++;
        if (numSpawned >= numToSpawn)
        {
            gameObject.SetActive(false);
        }
    }
}
