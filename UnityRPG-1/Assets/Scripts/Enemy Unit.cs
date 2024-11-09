using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public string enemyName;
    public int health;
    public int attackPower;
    public Vector2Int currentPosition;

    public float moveSpeed = 5f;

    // You can extend this with additional properties as needed
    void Start()
    {
        // Initialize values for your enemy
        health = 100;
        attackPower = 10;
        // Set starting position on the grid
        currentPosition = new Vector2Int(5, 5); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle death (e.g., remove from the game, play animation)
        Destroy(gameObject);
    }
}
