using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody _enemyBody;

    private GameObject _player;
    
    // Start is called before the first frame update
    void Start()
    {

        _enemyBody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var direction = (_player.transform.position - _enemyBody.position).normalized;
        _enemyBody.AddForce(direction * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
