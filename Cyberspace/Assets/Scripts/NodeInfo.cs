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
    public bool spawn;
    public GameObject spawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
