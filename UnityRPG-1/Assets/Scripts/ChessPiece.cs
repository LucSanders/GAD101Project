using UnityEngine;
public class ChessPiece : MonoBehaviour
{
    public bool isWhite;  // Whether the piece is white or black
    public Vector2Int currentGridPosition;  // Current position on the grid

    // This can be overridden by specific piece classes to check valid moves
    public virtual bool IsValidMove(Vector2Int targetPosition)
    {
        return false;  // Default implementation does nothing
    }

    // Move to the target position on the grid
    public void MoveTo(Vector2Int targetPosition)
    {
        // Check if the target position has an opposing piece
        ChessPiece targetPiece = FindPieceAtPosition(targetPosition);
        if (targetPiece != null)
        {
            CapturePiece(targetPiece);
        }

        // Move the piece
        transform.position = new Vector2(targetPosition.x, targetPosition.y);
        currentGridPosition = targetPosition;
    }

    // Find if a piece exists at the target position
    ChessPiece FindPieceAtPosition(Vector2Int targetPosition)
    {
        ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();
        foreach (var piece in allPieces)
        {
            if (piece.currentGridPosition == targetPosition)
            {
                return piece;
            }
        }
        return null;  // No piece found at the target position
    }

    // Handle the capture of an opponent's piece
    public void CapturePiece(ChessPiece piece)
    {
        // If the piece belongs to the opponent, capture it
        if (piece.isWhite != this.isWhite)
        {
            Debug.Log(this.isWhite ? "White captures a piece!" : "Black captures a piece!");
            Destroy(piece.gameObject);  // Destroy the captured piece
        }
    }
}
