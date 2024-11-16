using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    public override bool IsValidMove(Vector2Int targetPosition)
    {
        // Queen moves like both a rook and bishop
        int dx = Mathf.Abs(targetPosition.x - currentGridPosition.x);
        int dy = Mathf.Abs(targetPosition.y - currentGridPosition.y);
        return (dx == dy || targetPosition.x == currentGridPosition.x || targetPosition.y == currentGridPosition.y);
    }
}
