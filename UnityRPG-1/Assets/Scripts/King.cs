using UnityEngine;

public class King : ChessPiece
{
    public override bool IsValidMove(Vector2Int targetPosition)
    {
        int dx = Mathf.Abs(targetPosition.x - currentGridPosition.x);
        int dy = Mathf.Abs(targetPosition.y - currentGridPosition.y);

        // King moves one square in any direction
        return (dx <= 1 && dy <= 1);
    }
}
