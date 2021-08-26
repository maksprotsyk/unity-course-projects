using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float upperBound = 30.0f;

    public float lowerBound = -20.0f;

    public bool triggerGameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentZ = transform.position.z;
        if (currentZ > upperBound || currentZ < lowerBound)
        {
            Destroy(gameObject);
            if (triggerGameOver)
            {
                Debug.Log("GameOver");
            }
        }
        
        
    }
}
