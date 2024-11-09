using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public EnemyUnit enemyUnit;
    public Transform player;
    public float detectionRange = 5f;

    private bool isMoving = false;

    void Start()
    {
        enemyUnit = GetComponent<EnemyUnit>();
    }

    void Update()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            if (!isMoving)
            {
                Debug.Log("Enemy detected! Starting move...");
                StartCoroutine(MoveTowardsPlayer());
            }
        }
    }

    private IEnumerator MoveTowardsPlayer()
    {
        isMoving = true;
        Debug.Log("MoveTowardsPlayer coroutine started.");

        Vector3 targetPosition = player.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        float distance = Vector3.Distance(transform.position, targetPosition);
        float timeToMove = distance / enemyUnit.moveSpeed;

        // Move towards the player
        float elapsedTime = 0;
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null; // Ensure it waits until the next frame
        }

        // Once the enemy reaches the player, stop moving
        transform.position = targetPosition;
        Debug.Log("Enemy reached the player!");

        // Perform any attack logic here, for now just print
        AttackPlayer();
        isMoving = false;
    }

    void AttackPlayer()
    {
        Debug.Log("Enemy attacks player!");
        // Implement the attack logic (e.g., reduce player health)
    }
}
