using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject redEnemyPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 0.5f; // можно менять в рантайме

    private Coroutine spawnRoutine;

    private int level = 0;

    void Start()
    {
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(1f); // первая задержка перед стартом

        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
            // при следующем цикле WaitForSeconds возьмёт новое значение spawnInterval
        }
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    void SpawnEnemy()
    {
        if (!redEnemyPrefab || !enemyPrefab) return;
        Vector2 spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
        var shouldSpawnRed = Random.Range(0, 100) < level;
        Instantiate(shouldSpawnRed ? redEnemyPrefab : enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Опционально: если нужно принудительно перезапустить с новым интервалом
    public void RestartSpawner()
    {
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(SpawnLoop());
    }
}