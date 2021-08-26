using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    
    public float range = 10.0f;

    public float speed = 15.0f;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentX = transform.position.x;
        horizontalInput = Input.GetAxis("Horizontal");
        if (!((currentX < -range && horizontalInput < 0) || (currentX > range && horizontalInput > 0)))
        {
            transform.Translate(Vector3.right * (horizontalInput * Time.deltaTime * speed));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
