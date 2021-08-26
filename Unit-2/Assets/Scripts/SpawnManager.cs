using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public Vector3 spawnPosition = new Vector3(0, 0, 20);
    public float spawnRange = 10.0f;
    public float spawnInterval = 1.5f;
    public float spawnStart = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), spawnStart, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(
            animalPrefabs[animalIndex],
            new Vector3(spawnPosition.x + Random.Range(-spawnRange, spawnRange), spawnPosition.y, spawnPosition.z),
            animalPrefabs[animalIndex].transform.rotation
        );
    }
}
