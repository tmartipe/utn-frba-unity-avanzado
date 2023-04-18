using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAnimator : MonoBehaviour
{
    //todo: Complete code with Unity Input System 1.5.1 Use Actions Asset aproach.
    private EnemyInputActions _inputActions;
    private Vector2 _moveVector;
    private Animator _animator;
    private static readonly int InputStrength = Animator.StringToHash("InputStrength");
    private static readonly int Shoot = Animator.StringToHash("Shoot");

    private void Awake()
    {
        _inputActions = new EnemyInputActions();
        _animator = GetComponent<Animator>();
        _inputActions.Animations.Shoot.performed += OnShoot;
    }

    void Update()
    {
        _moveVector = _inputActions.Animations.Run.ReadValue<Vector2>();
        _animator.SetFloat(InputStrength,Mathf.Abs(_moveVector.x));
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        _animator.SetTrigger(Shoot);
    }

    private void OnEnable()
    {
        _inputActions.Animations.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Animations.Disable();
    }
}
