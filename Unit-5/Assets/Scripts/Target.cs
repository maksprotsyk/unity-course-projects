using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{

    private Rigidbody _targetRb;

    public float minSpeed = 12;
    public float maxSpeed = 16;

    public float maxTorque = 10;

    public float xRange = 4;

    public float yPos = -6;

    private GameManager _gameManager;

    public int pointsCount;

    public ParticleSystem destroyParticles;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _targetRb = GetComponent<Rigidbody>();
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        
        _targetRb.AddTorque(
            RandomTorque(), 
            RandomTorque(),
            RandomTorque(),
            ForceMode.Impulse
            );

        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        _gameManager.UpdateScore(pointsCount);
        Destroy(gameObject);
        Instantiate(destroyParticles, transform.position, destroyParticles.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_gameManager.isGameActive)
        {
            return;
        }
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }
    

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPos);
    }
    
}
