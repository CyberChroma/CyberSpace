using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour {

    public enum NodeType
    {
        normal,
        loop,
        end
    }

    public NodeType nodeType;
    public float speed;
    public int loopTo;
    public GameObject[] enemiesToSpawn;

    public void Spawn () {
        foreach (GameObject enemy in enemiesToSpawn)
        {
            enemy.SetActive(true);
        }
        enemiesToSpawn = null;
    }
}
