using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveF : MonoBehaviour {

    public NodeInfo[] nodes;

    [HideInInspector] public GameObject splitCollider;
    private int currentNode = 1;
    private int lastNode = 0;
    private float perc = 0;
    private Vector3 midPoint;
    private Vector3 m1;
    private Vector3 m2;

	void Update () {
        perc += (1 / Vector3.Distance(nodes[lastNode].transform.position, nodes[currentNode].transform.position)) * nodes[currentNode].speed * Time.deltaTime;
        if (Vector3.Angle(nodes[lastNode].transform.forward, nodes[currentNode].transform.position - nodes[lastNode].transform.position) > 0)
        {
            midPoint = nodes[lastNode].transform.position + nodes[lastNode].transform.forward * Vector3.Distance(nodes[lastNode].transform.position, nodes[currentNode].transform.position) / Mathf.Sqrt(2 * (1 - Mathf.Cos((180 - 2 * Vector3.Angle(nodes[lastNode].transform.forward, nodes[currentNode].transform.position - nodes[lastNode].transform.position)) * Mathf.Deg2Rad)));
        }
        else
        {
            midPoint = (nodes[lastNode].transform.position + nodes[currentNode].transform.position) / 2;
        }
        m1 = Vector3.Lerp(nodes[lastNode].transform.position, midPoint, perc);
        m2 = Vector3.Lerp(midPoint, nodes[currentNode].transform.position, perc);
        transform.position = Vector3.Lerp (m1, m2, perc);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Slerp(nodes[lastNode].transform.rotation, nodes[currentNode].transform.rotation, perc), 0.5f);
        if (Vector3.Distance(transform.position, nodes[currentNode].transform.position) <= 0.1f && Quaternion.Angle(transform.rotation, nodes[currentNode].transform.rotation) <= 1f)
        {
            lastNode = currentNode;
            if (nodes[lastNode].nodeType == NodeInfo.NodeType.normal)
            {
                currentNode++;
                if (currentNode >= nodes.Length)
                {
                    enabled = false;
                }
            }
            else if (nodes[lastNode].nodeType == NodeInfo.NodeType.move)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    if (nodes[i].gameObject == nodes[lastNode].moveTo)
                    {
                        currentNode = i;
                    }
                }
            }

            else if (nodes[lastNode].nodeType == NodeInfo.NodeType.split)
            {
                if (splitCollider != null)
                {
                    SplitInfo[] splitInfo = splitCollider.GetComponentInParent<NodeInfo>().splitInfo;
                    for (int i = 0; i < splitInfo.Length; i++)
                    {
                        if (splitInfo[i].collider == splitCollider)
                        {
                            for (int j = 0; j < nodes.Length; j++)
                            {
                                if (nodes[j].gameObject == splitInfo[i].splitTo)
                                {
                                    currentNode = j;
                                }
                            }
                        }
                    }
                    splitCollider = null;
                }
            }
            else if (nodes[lastNode].nodeType == NodeInfo.NodeType.end)
            {
                FindObjectOfType<GameManager>().EndLevel();
                enabled = false;
            }
            if (nodes[lastNode].enemiesToSpawn != null)
            {
                nodes[lastNode].Spawn();
            }
            perc = 0;
        }
	}
}
