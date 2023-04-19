using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rb;
    
    private readonly float _timeBetweenAnim = 2f;
    private float _timer;
    [SerializeField]
    private int _animState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _timer = _timeBetweenAnim;
    }

    void Update()
    {
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
}
