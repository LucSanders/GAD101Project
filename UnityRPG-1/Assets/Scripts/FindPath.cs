using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public AStarPathfinder Pathfinder;
    public Grid Grid;
    public Vector2Int TargetPosition;

    private List<Node> currentPath;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // For testing, use Space to find path
        {
            currentPath = Pathfinder.FindPath(new Vector2Int((int)transform.position.x, (int)transform.position.y), TargetPosition, Grid);
        }

        if (currentPath != null && currentPath.Count > 0)
        {
            MoveAlongPath();
        }
    }

    private void MoveAlongPath()
    {
        Node nextNode = currentPath[0];
        transform.position = new Vector2(nextNode.Position.x, nextNode.Position.y);

        if (Vector2.Distance(transform.position, nextNode.Position) < 0.1f)
        {
            currentPath.RemoveAt(0);
        }
    }
}

