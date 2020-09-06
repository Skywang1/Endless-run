using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PropGeneratorBase : MonoBehaviour
{
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 5f;
    public List<Transform> spawnPoints;
    public List<GameObject> prefabs;
    protected bool spawning = false;

    public void StartSpawn()
    {
        spawning = true;
        StartCoroutine(DoSpawn());
    }

    public void StopSpawn()
    {
        spawning = false;
    }

    protected virtual IEnumerator DoSpawn()
    {
        while (spawning)
        {
            SpawnAtPosition(GetRandomSpawnPoint.position);
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }

    public Transform GetRandomSpawnPoint => spawnPoints[Random.Range(0, spawnPoints.Count)];

    public GameObject GetRandomPrefab => prefabs[Random.Range(0, prefabs.Count)];

    public void SpawnAtPosition(Vector3 pos) => Instantiate(GetRandomPrefab, pos, Quaternion.identity);

    public float GetRandomDelay => Random.Range(spawnIntervalMin, spawnIntervalMax);
}