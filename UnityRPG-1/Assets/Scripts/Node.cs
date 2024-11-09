using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{
    public Vector2Int Position;
    public float GCost; // Cost from start to this node
    public float HCost; // Heuristic cost to end node
    public float FCost => GCost + HCost; // Total cost
    public Node Parent;

    public Node(Vector2Int position)
    {
        Position = position;
    }
}
