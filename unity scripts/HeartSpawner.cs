using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heartPrefab;
    public int nOfheartsToSpawn;
    public float spawnRadiusx = 10f;
    public float spawnRadiusy = 10f;
    public LayerMask avoidLayers;

    void Start()
    {
        Spawnhearts();
    }

    void Spawnhearts()
    {
        int spawnedhearts = 0;

        while (spawnedhearts< nOfheartsToSpawn)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range( -spawnRadiusx,0),
                Random.Range(-spawnRadiusy, spawnRadiusy)
            );

            if (IsValidSpawnPosition(randomPosition))
            {
                Instantiate(heartPrefab, randomPosition, Quaternion.identity);
                spawnedhearts++;
            }
        }
    }

    bool IsValidSpawnPosition(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.5f, avoidLayers);
        return colliders.Length == 0;
    }
}

