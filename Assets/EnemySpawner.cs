using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
