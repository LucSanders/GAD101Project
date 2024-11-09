using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    public enum TurnType { Player, Enemy }
    public TurnType currentTurn;

    public List<EnemyUnit> enemies; // List of enemy units
    public PlayerUnit player; // Player unit
    private bool isPlayerTurn = true; // Flag to track whose turn it is

    public float turnDuration = 2f; // Duration of each turn

    void Start()
    {
        // Start with the player's turn
        currentTurn = TurnType.Player;
        StartCoroutine(TurnSequence());
    }

    void Update()
    {
        // Optionally handle player input here when it's the player's turn
        if (currentTurn == TurnType.Player)
        {
            // Handle player input here (e.g., move, attack)
        }
    }

    private IEnumerator TurnSequence()
    {
        while (true) // Keep alternating turns indefinitely
        {
            if (currentTurn == TurnType.Player)
            {
                Debug.Log("Player's turn...");
                yield return StartCoroutine(PlayerTurn());
            }
            else if (currentTurn == TurnType.Enemy)
            {
                Debug.Log("Enemy's turn...");
                yield return StartCoroutine(EnemyTurn());
            }
        }
    }

    private IEnumerator PlayerTurn()
    {
        // Simulate player's turn duration (e.g., 2 seconds for demo purposes)
        yield return new WaitForSeconds(turnDuration);

        // After the player finishes their turn, end the player's turn
        Debug.Log("Player's turn ended.");
        currentTurn = TurnType.Enemy; // Switch to enemy's turn
    }

    private IEnumerator EnemyTurn()
    {
        // Simulate enemy's turn duration (e.g., 2 seconds for demo purposes)
        yield return new WaitForSeconds(turnDuration);

        // After the enemy finishes their turn, end the enemy's turn
        Debug.Log("Enemy's turn ended.");
        currentTurn = TurnType.Player; // Switch to player's turn
    }
}
