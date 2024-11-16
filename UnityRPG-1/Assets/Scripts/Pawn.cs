using UnityEngine;

public class Pawn : ChessPiece
{
    public override bool IsValidMove(Vector2Int targetPosition)
    {
        int direction = isWhite ? 1 : -1; // White moves up, black moves down

        // Normal move: 1 square forward
        if (targetPosition.x == currentGridPosition.x && targetPosition.y == currentGridPosition.y + direction)
        {
            return true;
        }

        // First move: can move two squares forward
        if (currentGridPosition.y == (isWhite ? 1 : 6) && targetPosition.x == currentGridPosition.x && targetPosition.y == currentGridPosition.y + (2 * direction))
        {
            return true;
        }

        return false;
    }
}
