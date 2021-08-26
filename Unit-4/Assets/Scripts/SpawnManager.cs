using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerUpPrefab;

    public float spawnRange;

    private int _enemyCount;

    private int _waveNumber;
    // Start is called before the first frame update
    void Start()
    {
        _waveNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = FindObjectsOfType<Enemy>().Length;
        if (_enemyCount == 0)
        {
            SpawnEnemyWave(_waveNumber);
            _waveNumber += 1;
            SpawnObject(powerUpPrefab);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        var x = Random.Range(-spawnRange, spawnRange);
        var z = Random.Range(-spawnRange, spawnRange);
        return new Vector3(x, 0, z);
    }

    private void SpawnEnemyWave(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnObject(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);
        }
    }

    private void SpawnObject(GameObject obj)
    {
        Instantiate(
            obj,
            GenerateSpawnPosition(),
            obj.transform.rotation
        );
    }
}
