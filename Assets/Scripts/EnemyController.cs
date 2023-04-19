using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    
    private readonly float _timeBetweenAnim = 2f;
    private float _timer;
    private int _animState;
    private float _shootInterval;

    private float dmg = 5f;

    private Shooting _shooting;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _timer = _timeBetweenAnim;
        _shooting = GetComponent<Shooting>();
    }

    void Update()
    {
        if(_animState == 2) Shoot();
        if (_timer > 0) {
            _timer -= Time.deltaTime;
        }
        else
        {
            _timer = _timeBetweenAnim;
            UpdateAnimState();
            _animator.SetFloat("State", _animState);
        }
    }

    private void FixedUpdate()
    {
        Movement();
        _rb.AddForce(Physics.gravity * 5, ForceMode.Acceleration);
    }

    private void UpdateAnimState()
    {
        if (_animState == 2)
            _animState = 0;
        else
            _animState++;
    }
    
    private void Movement()
    {
        Vector3 movement = _animState != 1 ? Vector3.zero : Vector3.forward;
        _rb.MovePosition(transform.position + movement * Time.deltaTime);
    }

    void Shoot()
    {
        if (_shootInterval <= 0)
        {
            _shootInterval = .5f;
            _shooting.ShootToPlayer(dmg);
        }
        else
            _shootInterval -= Time.deltaTime;
    }
    
}
