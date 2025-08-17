using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 10f;
    public float spawnInterval = 0.5f; // можно менять в рантайме

    private Coroutine spawnRoutine;

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

    void SpawnEnemy()
    {
        Vector2 spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Опционально: если нужно принудительно перезапустить с новым интервалом
    public void RestartSpawner()
    {
        if (spawnRoutine != null)
            StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(SpawnLoop());
    }
}