using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // Array of spawn points
    public int numberOfEnemies = 5; // Number of enemies to spawn at each interval
    public int maxNumberOfEnemies = 10; // Maximum number of enemies to spawn
    public float spawnInterval = 5f; // Time interval between spawns
    public float spawnOffset = 1f; // Offset for spawning enemies side by side

    private int currentNumberOfEnemies = 0; // Track current number of spawned enemies
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime && currentNumberOfEnemies < maxNumberOfEnemies)
        {
            SpawnEnemies();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemies()
    {
        Debug.Log("Spawning enemies...");
        for (int i = 0; i < numberOfEnemies && currentNumberOfEnemies < maxNumberOfEnemies; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Choose a random spawn point
            Vector3 spawnPosition = spawnPoint.position + new Vector3(i * spawnOffset, 0, 0); // Apply the offset

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            Debug.Log("Enemy instantiated at position: " + newEnemy.transform.position);
            currentNumberOfEnemies++;

            // Optional: Name the enemy for easier identification in the hierarchy
            newEnemy.name = "Enemy_" + currentNumberOfEnemies;
        }
    }
}

