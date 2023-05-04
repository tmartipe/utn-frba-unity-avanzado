using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DoorState
{
    Open,
    Closed
}

public class PuertaController : MonoBehaviour
{
    private DoorState _doorState;
    
    private Animator _buttonAnim;
    public Animator _doorAnim;

    [SerializeField]
    private float _doorTimer;
    public float doorTime = 2f;
    
    private void Awake()
    {
        _buttonAnim = GetComponent<Animator>();
        _doorState = DoorState.Closed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            _buttonAnim.SetTrigger("Pushed");
            if (_doorState.Equals(DoorState.Closed))
            {
                _doorAnim.SetTrigger("Abrir");
                _doorTimer = doorTime;
                _doorState = DoorState.Open;
            }else if (_doorState.Equals(DoorState.Open))
            {
                _doorTimer = doorTime;
            }
        }
    }

    private void Update()
    {
        if (_doorState.Equals(DoorState.Open) && _doorTimer <= 0)
        {
            _doorAnim.SetTrigger("Cerrar");
            _doorState = DoorState.Closed;
        }
        else if(_doorState == DoorState.Open)
        {
            _doorTimer -= Time.deltaTime;
        }
}
}
