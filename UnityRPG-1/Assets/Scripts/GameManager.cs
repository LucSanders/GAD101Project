using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TurnManager turnManager;
    public AIManager aiManager;

    private ChessPiece selectedPiece;

    void Start()
    {
        aiManager = FindObjectOfType<AIManager>();  // Find AIManager in the scene
    }

    void Update()
    {
        // Player makes a move when it's White's turn
        if (turnManager.IsWhiteTurn())
        {
            if (Input.GetMouseButtonDown(0))  // Left-click to select a piece or move it
            {
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2Int gridPos = new Vector2Int(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));

                // Select the piece if it's on the current player's turn
                SelectPiece(gridPos);
            }
        }

        // If it's Black's turn, let the AI make a move
        if (turnManager.IsBlackTurn())
        {
            aiManager.TakeTurn();  // Let AI play Black's turn
        }
    }

    void SelectPiece(Vector2Int gridPos)
    {
        // Check if the selected grid position has a piece
        ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();
        foreach (var piece in allPieces)
        {
            if (piece.currentGridPosition == gridPos)
            {
                // Check if it's the correct player's turn (White's turn)
                if (turnManager.CanMove(piece))
                {
                    selectedPiece = piece;
                    return;  // Piece selected, exit
                }
            }
        }

        // If a piece was selected and the move is valid, move it
        if (selectedPiece != null && selectedPiece.IsValidMove(gridPos))
        {
            selectedPiece.MoveTo(gridPos);  // Move the piece

            turnManager.SwitchTurn();  // Switch turn after move
            selectedPiece = null;  // Deselect the piece after moving
        }
    }
}
