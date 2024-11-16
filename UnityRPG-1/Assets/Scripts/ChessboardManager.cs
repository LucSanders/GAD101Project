using UnityEngine;

public class ChessboardManager : MonoBehaviour
{
    // Prefabs for the pieces
    public GameObject whitePawnPrefab;
    public GameObject blackPawnPrefab;
    public GameObject whiteRookPrefab;
    public GameObject blackRookPrefab;
    public GameObject whiteBishopPrefab;
    public GameObject blackBishopPrefab;
    public GameObject whiteKnightPrefab;
    public GameObject blackKnightPrefab;
    public GameObject whiteKingPrefab;
    public GameObject blackKingPrefab;
    public GameObject whiteQueenPrefab;
    public GameObject blackQueenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy any existing pieces on the board before setting up new ones
        DestroyExistingPieces();

        // Setup the chessboard with the pieces
        SetupBoard();
    }

    // Destroy all existing pieces on the board (if any)
    void DestroyExistingPieces()
    {
        // Loop through all children of the ChessboardManager (the pieces)
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Setup the initial chessboard with pieces
    void SetupBoard()
    {
        // White pieces
        SpawnPiece(whitePawnPrefab, 0, 1, true);
        SpawnPiece(whitePawnPrefab, 1, 1, true);
        SpawnPiece(whitePawnPrefab, 2, 1, true);
        SpawnPiece(whitePawnPrefab, 3, 1, true);
        SpawnPiece(whitePawnPrefab, 4, 1, true);
        SpawnPiece(whitePawnPrefab, 5, 1, true);
        SpawnPiece(whitePawnPrefab, 6, 1, true);
        SpawnPiece(whitePawnPrefab, 7, 1, true);
        
        // White back row pieces
        SpawnPiece(whiteRookPrefab, 0, 0, true);
        SpawnPiece(whiteRookPrefab, 7, 0, true);
        SpawnPiece(whiteKnightPrefab, 1, 0, true);
        SpawnPiece(whiteKnightPrefab, 6, 0, true);
        SpawnPiece(whiteBishopPrefab, 2, 0, true);
        SpawnPiece(whiteBishopPrefab, 5, 0, true);
        SpawnPiece(whiteKingPrefab, 4, 0, true);
        SpawnPiece(whiteQueenPrefab, 3, 0, true);

        // Black pieces
        SpawnPiece(blackPawnPrefab, 0, 6, false);
        SpawnPiece(blackPawnPrefab, 1, 6, false);
        SpawnPiece(blackPawnPrefab, 2, 6, false);
        SpawnPiece(blackPawnPrefab, 3, 6, false);
        SpawnPiece(blackPawnPrefab, 4, 6, false);
        SpawnPiece(blackPawnPrefab, 5, 6, false);
        SpawnPiece(blackPawnPrefab, 6, 6, false);
        SpawnPiece(blackPawnPrefab, 7, 6, false);

        // Black back row pieces
        SpawnPiece(blackRookPrefab, 0, 7, false);
        SpawnPiece(blackRookPrefab, 7, 7, false);
        SpawnPiece(blackKnightPrefab, 1, 7, false);
        SpawnPiece(blackKnightPrefab, 6, 7, false);
        SpawnPiece(blackBishopPrefab, 2, 7, false);
        SpawnPiece(blackBishopPrefab, 5, 7, false);
        SpawnPiece(blackKingPrefab, 4, 7, false);
        SpawnPiece(blackQueenPrefab, 3, 7, false);
    }

    // Helper method to spawn pieces
    void SpawnPiece(GameObject prefab, int x, int y, bool isWhite)
    {
        // Check if prefab is assigned
        if (prefab == null)
        {
            Debug.LogError("Prefab is not assigned!");
            return;
        }

        // Instantiate the piece at the correct position
        GameObject piece = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);

        // Get the ChessPiece script from the instantiated piece
        ChessPiece chessPiece = piece.GetComponent<ChessPiece>();

        if (chessPiece != null)
        {
            // Set the piece's current position and color
            chessPiece.currentGridPosition = new Vector2Int(x, y);
            chessPiece.isWhite = isWhite;
        }
        else
        {
            Debug.LogError("ChessPiece script is not attached to the prefab: " + prefab.name);
        }
    }
}
