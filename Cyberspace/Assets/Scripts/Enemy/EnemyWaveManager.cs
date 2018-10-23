using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWave
{
    public GameObject[] enemies;
}

public class EnemyWaveManager : MonoBehaviour {

    public EnemyWave[] enemyWaves;
    public GameObject[] boundaries;

    private int wave = -1;
    private bool active;
    private bool waveComplete;
    private bool changingWave;

	// Use this for initialization
	void OnEnable () {
        foreach (EnemyWave enemyWave in enemyWaves)
        {
            foreach (GameObject enemy in enemyWave.enemies)
            {
                enemy.SetActive(false);
            }
        }
        foreach (GameObject boundary in boundaries)
        {
            boundary.SetActive(false);
        }
	}

    void OnDisable () {
        foreach (EnemyWave enemyWave in enemyWaves)
        {
            foreach (GameObject enemy in enemyWave.enemies)
            {
                enemy.SetActive(false);
            }
        }
        foreach (GameObject boundary in boundaries)
        {
            boundary.SetActive(false);
        }
        active = false;
        wave = -1;
        changingWave = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (active && !changingWave)
        {
            waveComplete = true;
            foreach (GameObject enemy in enemyWaves[wave].enemies)
            {
                if (enemy.activeInHierarchy)
                {
                    waveComplete = false;
                }
            }
            if (waveComplete)
            {
                StartCoroutine(NextWave());
            }
        }
	}

    IEnumerator NextWave () {
        changingWave = true;
        yield return new WaitForSeconds(1);
        wave++;
        if (wave < enemyWaves.Length)
        {
            foreach (GameObject enemy in enemyWaves[wave].enemies)
            {
                enemy.SetActive(true);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
        changingWave = false;
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag("Player") && !active)
        {
            active = true;
            foreach (GameObject boundary in boundaries)
            {
                boundary.SetActive(true);
            }
            StartCoroutine(NextWave());
        }
    }
}
