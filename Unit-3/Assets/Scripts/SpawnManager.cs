using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 spawnPosition;

    public GameObject obstacle;

    public float minWaitTime;
    public float maxWaitTime;
    public float startDelay;

    private PlayerController _playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke(nameof(SpawnObstacle), startDelay);
        
    }

    void SpawnObstacle()
    {
        if (_playerController.gameOver)
        {
            return;
        }
        Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        Invoke(nameof(SpawnObstacle), Random.Range(minWaitTime, maxWaitTime));
    }
    
}
