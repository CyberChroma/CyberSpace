using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveF : MonoBehaviour {

    public Transform[] pointsObj;

    [HideInInspector] public GameObject splitCollider;
    private int currentNode = 1;
    private int lastNode = 0;
    private float perc = 0;
    //private BezierCurve path;
    private NodeInfo[] nodes;
    private BezierPoint[] points;

    void Awake () {
        nodes = new NodeInfo[pointsObj.Length];
        points = new BezierPoint[pointsObj.Length];
        for (int i = 0; i < pointsObj.Length; i++)
        {
            nodes[i] = pointsObj[i].GetComponent<NodeInfo>();
            points[i] = pointsObj[i].GetComponent<BezierPoint>();
        }
        //path = points[0].curve;
    }

	void FixedUpdate () {
        perc += (nodes[currentNode].speed / BezierCurve.ApproximateLength(points[lastNode], points[currentNode]) * Time.deltaTime);
        Debug.DrawRay(BezierCurve.GetPoint(points[lastNode], points[currentNode], perc), new Vector3 (1, 1, 1) * 10, Color.red);
        transform.position = BezierCurve.GetPoint(points[lastNode], points[currentNode], perc);
        Vector3 lookRot = BezierCurve.GetPoint(points[lastNode], points[currentNode], perc + 0.001f) - transform.position;
        if (lookRot != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookRot);
        }
        if (perc > 1f)
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
