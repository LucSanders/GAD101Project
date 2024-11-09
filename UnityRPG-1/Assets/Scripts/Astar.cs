using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinder : MonoBehaviour
{
    public List<Node> FindPath(Vector2Int start, Vector2Int target, Grid grid)
    {
        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        Node startNode = grid.GetNode(start);
        Node targetNode = grid.GetNode(target);
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].FCost < currentNode.FCost || (openSet[i].FCost == currentNode.FCost && openSet[i].HCost < currentNode.HCost))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode.Position == targetNode.Position)
            {
                return RetracePath(startNode, currentNode);
            }

            foreach (Node neighbor in grid.GetNeighbors(currentNode))
            {
                if (closedSet.Contains(neighbor)) continue;

                float newCostToNeighbor = currentNode.GCost + GetDistance(currentNode, neighbor);
                if (newCostToNeighbor < neighbor.GCost || !openSet.Contains(neighbor))
                {
                    neighbor.GCost = newCostToNeighbor;
                    neighbor.HCost = GetDistance(neighbor, targetNode);
                    neighbor.Parent = currentNode;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null; // No path found
    }

    private List<Node> RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }
        path.Reverse();
        return path;
    }

    private float GetDistance(Node a, Node b)
    {
        return Vector2Int.Distance(a.Position, b.Position);
    }
}
