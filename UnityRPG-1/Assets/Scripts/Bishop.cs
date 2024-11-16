using UnityEngine;

public class Bishop : ChessPiece
{
    public override bool IsValidMove(Vector2Int targetPosition)
    {
        // Bishop moves diagonally: the absolute difference in x should equal the absolute difference in y
        int dx = Mathf.Abs(targetPosition.x - currentGridPosition.x);
        int dy = Mathf.Abs(targetPosition.y - currentGridPosition.y);

        // Valid move if the piece moves diagonally (equal change in x and y)
        return dx == dy;
    }
}
