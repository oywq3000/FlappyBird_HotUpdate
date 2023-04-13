using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    public bool isDead = false;

    public float upForce = 100f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
  
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(Vector2.up*upForce);
            _animator.SetTrigger("Flap");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        _animator.SetTrigger("Dead");
        
        GameManager.Instance.OnDead();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.OnOverObstacle();
        other.GetComponent<BoxCollider2D>().enabled = false;
    }
}
