using UnityEngine;
using System.Collections.Generic;

public class AIManager : MonoBehaviour
{
    private TurnManager turnManager;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();  // Find TurnManager in the scene
    }

    // Call this method to make the AI take its turn
    public void TakeTurn()
    {
        if (turnManager.IsBlackTurn())  // Only let the AI move when it's Black's turn
        {
            Debug.Log("AI's turn (Black)");

            // Find all black pieces
            ChessPiece[] blackPieces = FindPieces(false);  // false means Black pieces
            List<ChessPiece> validPieces = new List<ChessPiece>();

            // Find pieces that have at least one valid move
            foreach (ChessPiece piece in blackPieces)
            {
                List<Vector2Int> validMoves = GetValidMoves(piece);
                if (validMoves.Count > 0)
                {
                    validPieces.Add(piece);
                }
            }

            if (validPieces.Count > 0)
            {
                // Pick a random piece that has a valid move
                ChessPiece selectedPiece = validPieces[Random.Range(0, validPieces.Count)];
                List<Vector2Int> validMovesForPiece = GetValidMoves(selectedPiece);

                // Pick a random valid move for the selected piece
                Vector2Int moveTo = validMovesForPiece[Random.Range(0, validMovesForPiece.Count)];

                // Move the piece and switch turns
                selectedPiece.MoveTo(moveTo);
                turnManager.SwitchTurn();  // Switch to White's turn after AI's move
            }
        }
    }

    // Get all valid moves for a specific piece
    private List<Vector2Int> GetValidMoves(ChessPiece piece)
    {
        List<Vector2Int> validMoves = new List<Vector2Int>();

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Vector2Int targetPos = new Vector2Int(x, y);
                if (piece.IsValidMove(targetPos))
                {
                    validMoves.Add(targetPos);
                }
            }
        }

        return validMoves;
    }

    // Get all black pieces on the board
    private ChessPiece[] FindPieces(bool isWhite)
    {
        ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();
        List<ChessPiece> pieces = new List<ChessPiece>();

        foreach (var piece in allPieces)
        {
            if (piece.isWhite == isWhite)  // true for White pieces, false for Black pieces
            {
                pieces.Add(piece);
            }
        }

        return pieces.ToArray();
    }
}
