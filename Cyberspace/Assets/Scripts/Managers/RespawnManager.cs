using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour {

    public Checkpoint startPoint;

    private bool respawning = true;
    private GameObject player;
    private GameObject camPivot;
    private Health playerHealth;
    private InputManager inputManager;
    private Checkpoint activeCheckpoint;
    private GameManager gameManager;

    private GameObject[] gameObjectEvents;
    private bool[] completedEvents;
    private BitsUI bitsUI;
    private int bits;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<Health>();
        camPivot = GameObject.Find("Camera Pivot");
        inputManager = FindObjectOfType<InputManager>();
        activeCheckpoint = startPoint;
        gameManager = FindObjectOfType<GameManager>();
        player.SetActive(false);
        Transform enemiesParent = GameObject.Find("Enemies").transform;
        Transform hazardsParent = GameObject.Find("Hazards").transform;
        Transform enemyWavesParent = GameObject.Find("Enemy Waves").transform;
        Transform npcParent = GameObject.Find("NPCs").transform;
        gameObjectEvents = new GameObject[enemiesParent.childCount + hazardsParent.childCount + enemyWavesParent.childCount + npcParent.childCount];
        completedEvents = new bool[gameObjectEvents.Length];
        for (int i = 0; i < gameObjectEvents.Length; i++)
        {
            if (i < enemiesParent.childCount)
            {
                gameObjectEvents[i] = enemiesParent.GetChild(i).gameObject;
            }
            else if (i < enemiesParent.childCount + hazardsParent.childCount)
            {
                gameObjectEvents[i] = hazardsParent.GetChild(i - enemiesParent.childCount).gameObject;
            }
            else if (i < enemiesParent.childCount + hazardsParent.childCount + enemyWavesParent.childCount)
            {
                gameObjectEvents[i] = enemyWavesParent.GetChild(i - enemiesParent.childCount - hazardsParent.childCount).gameObject;
            }
            else
            {
                gameObjectEvents[i] = npcParent.GetChild(i - enemiesParent.childCount - hazardsParent.childCount - enemyWavesParent.childCount).gameObject;
            }
        }
        bitsUI = FindObjectOfType<BitsUI>();
        StartCoroutine(Respawn());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && playerHealth)
        {
            playerHealth.currentHealth = 0;
        }
        if (!respawning && playerHealth && playerHealth.currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
	}
        
    public void ActivateCheckpoint (Checkpoint newCheckpoint) {
        activeCheckpoint = newCheckpoint;
        for (int i = 0; i < gameObjectEvents.Length; i++)
        {
            if (!gameObjectEvents[i].activeInHierarchy)
            {
                completedEvents[i] = true;
            }
        }
        bits = bitsUI.bits;
    }

    public IEnumerator Die () {
        respawning = true;
        inputManager.canMove = false;
        player.SetActive(false);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameManager.fadeIn = false;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < completedEvents.Length; i++)
        {
            gameObjectEvents[i].SetActive(false);
            if (!completedEvents[i])
            {   
                gameObjectEvents[i].SetActive(true);
            }
        }
        bitsUI.SetBits(bits);
        StartCoroutine(Respawn());
    }

    public IEnumerator Respawn () {
        player.transform.position = activeCheckpoint.transform.position;
        player.transform.rotation = activeCheckpoint.transform.rotation;
        camPivot.transform.position = activeCheckpoint.transform.position;
        camPivot.transform.rotation = activeCheckpoint.transform.rotation;
        gameManager.fadeIn = true;
        activeCheckpoint.Respawn();
        yield return new WaitForSeconds(1);
        playerHealth.currentHealth = playerHealth.startHealth;
        player.SetActive(true);
        inputManager.canMove = true;
        respawning = false;
    }
}
