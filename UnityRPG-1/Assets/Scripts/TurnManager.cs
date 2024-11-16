using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private bool isWhiteTurn = true;  // Start with White's turn

    // Switch between White and Black turns
    public void SwitchTurn()
    {
        isWhiteTurn = !isWhiteTurn;  // Toggle turn
        Debug.Log(isWhiteTurn ? "White's turn" : "Black's turn");
    }

    // Check if it's White's turn
    public bool IsWhiteTurn()
    {
        return isWhiteTurn;
    }

    // Check if it's Black's turn
    public bool IsBlackTurn()
    {
        return !isWhiteTurn;
    }

    // Method to check if it's the current player's turn and they can move
    public bool CanMove(ChessPiece piece)
    {
        // Only allow the current player to move their pieces
        if ((isWhiteTurn && piece.isWhite) || (!isWhiteTurn && !piece.isWhite))
        {
            return true;  // The piece belongs to the current player
        }
        return false;  // It's not the player's turn
    }
}
