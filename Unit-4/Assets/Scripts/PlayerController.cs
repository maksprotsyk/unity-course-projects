using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameObject _focalPoint;
    private bool _hasPowerUp;
    public float powerUpStrength;
    public float powerUpDuration;
    public GameObject powerIndicator;
    public Vector3 powerUpOffset;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");
        _hasPowerUp = false;
        powerIndicator.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        var vertInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(_focalPoint.transform.forward * (speed * vertInput));
        powerIndicator.transform.position = transform.position + powerUpOffset;
    }

    IEnumerator PowerUpTimer()
    {
        powerIndicator.SetActive(true);
        yield return new WaitForSeconds(powerUpDuration);
        _hasPowerUp = false;
        powerIndicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpTimer());
        }

    }

    private void OnCollisionEnter(Collision other)
    {
         if (other.gameObject.CompareTag("Enemy") && _hasPowerUp)
         {
             Rigidbody enemyBody = other.gameObject.GetComponent<Rigidbody>();
             Vector3 direction = (enemyBody.position - transform.position).normalized;
             enemyBody.AddForce(direction * powerUpStrength, ForceMode.Impulse);
         }
    }
}
