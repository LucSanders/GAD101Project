using UnityEngine;

public class Rook : ChessPiece
{
    public override bool IsValidMove(Vector2Int targetPosition)
    {
        // Rook moves any number of squares in a row or column
        return targetPosition.x == currentGridPosition.x || targetPosition.y == currentGridPosition.y;
    }
}

