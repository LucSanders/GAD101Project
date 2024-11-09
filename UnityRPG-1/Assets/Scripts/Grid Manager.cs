using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Vector2Int gridSize;
    public float cellSize = 1f;

    // Returns a world position based on grid coordinates
    public Vector3 GetWorldPosition(Vector2Int gridPosition)
    {
        return new Vector3(gridPosition.x * cellSize, gridPosition.y * cellSize, 0);
    }

    // Returns grid coordinates based on world position
    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        int x = Mathf.RoundToInt(worldPosition.x / cellSize);
        int y = Mathf.RoundToInt(worldPosition.y / cellSize);
        return new Vector2Int(x, y);
    }
}
