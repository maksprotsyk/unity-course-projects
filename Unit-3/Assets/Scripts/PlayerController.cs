using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerBody;

    private Animator _animator;

    private AudioSource _audioSource;

    public AudioClip jumpSound;

    public AudioClip explosionSound;

    public ParticleSystem explosion;

    public ParticleSystem dirt;

    public float gravityModifier;

    public float jumpForce;

    private bool _isOnGround = true;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
        dirt.Play();
        
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && _isOnGround && !gameOver)
        {
            _playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("Jump_trig");
            _isOnGround = false;
            dirt.Stop();
            _audioSource.PlayOneShot(jumpSound, 1.0f);

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirt.Play();
        } else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game over");
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            _audioSource.PlayOneShot(explosionSound, 1.0f);
            dirt.Stop();
            explosion.Play();
        }
    }
}
