using UnityEngine;

public class Knight : ChessPiece
{
    public override bool IsValidMove(Vector2Int targetPosition)
    {
        // Knight moves in an "L" shape: 2 squares in one direction, 1 square perpendicular, or vice versa
        int dx = Mathf.Abs(targetPosition.x - currentGridPosition.x);
        int dy = Mathf.Abs(targetPosition.y - currentGridPosition.y);

        // Valid move if the movement is in an "L" shape: (2, 1) or (1, 2)
        return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
    }
}

