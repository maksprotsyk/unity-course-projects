using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    
    public float turnSpeed = 1.0f;

    private float _horizontalInput;

    private float _forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * (Time.deltaTime * speed * _forwardInput));
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * _horizontalInput);
    }
}
