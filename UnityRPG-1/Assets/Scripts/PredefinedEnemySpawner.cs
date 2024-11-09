using UnityEngine;

public class PredefinedEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;     // The enemy prefab
    public Vector3[] spawnLocations;  // Predefined spawn locations

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        foreach (var location in spawnLocations)
        {
            // Instantiate enemy at the given location
            Instantiate(enemyPrefab, location, Quaternion.identity);
        }
    }
}
