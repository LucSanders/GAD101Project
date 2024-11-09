using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int Width;
    public int Height;
    public Node[,] Nodes;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        Nodes = new Node[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Nodes[x, y] = new Node(new Vector2Int(x, y));
            }
        }
    }

    public Node GetNode(Vector2Int position)
    {
        return Nodes[position.x, position.y];
    }

    public List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        Vector2Int[] directions = {
            new Vector2Int(1, 0), new Vector2Int(-1, 0),
            new Vector2Int(0, 1), new Vector2Int(0, -1)
        };

        foreach (var direction in directions)
        {
            Vector2Int neighborPos = node.Position + direction;
            if (IsValidPosition(neighborPos))
            {
                neighbors.Add(GetNode(neighborPos));
            }
        }

        return neighbors;
    }

    private bool IsValidPosition(Vector2Int position)
    {
        return position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;
    }
}
