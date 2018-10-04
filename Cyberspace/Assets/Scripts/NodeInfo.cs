using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SplitInfo {
    public GameObject splitTo;
    public GameObject collider;
}

public class NodeInfo : MonoBehaviour {

    public enum NodeType
    {
        normal,
        move,
        split,
        end
    }

    public NodeType nodeType;
    public float speed;
    public GameObject moveTo;
    public SplitInfo[] splitInfo;
    public GameObject[] enemiesToSpawn;

    public void Spawn () {
        foreach (GameObject enemy in enemiesToSpawn)
        {
            enemy.SetActive(true);
        }
        enemiesToSpawn = null;
    }
}
