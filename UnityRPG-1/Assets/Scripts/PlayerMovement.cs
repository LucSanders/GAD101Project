using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2Int gridSize; // Define the size of your grid

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        HandleInput();
        MovePlayer();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W)) // Move Up
            Move(new Vector2Int(0, 1));
        if (Input.GetKeyDown(KeyCode.S)) // Move Down
            Move(new Vector2Int(0, -1));
        if (Input.GetKeyDown(KeyCode.A)) // Move Left
            Move(new Vector2Int(-1, 0));
        if (Input.GetKeyDown(KeyCode.D)) // Move Right
            Move(new Vector2Int(1, 0));
    }

    private void Move(Vector2Int direction)
    {
        Vector3 newPosition = targetPosition + new Vector3(direction.x, direction.y, 0);
        // Check boundaries
        if (IsValidPosition(newPosition))
        {
            targetPosition = newPosition;
        }
    }

    private bool IsValidPosition(Vector3 position)
    {
        // Ensure the new position is within the grid bounds
        return position.x >= 0 && position.x < gridSize.x &&
               position.y >= 0 && position.y < gridSize.y;
    }

    private void MovePlayer()
    {
        // Smoothly move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}

