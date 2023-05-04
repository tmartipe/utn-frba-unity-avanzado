using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum DoorState
{
    Open,
    Closed
}

public class PuertaController : MonoBehaviour
{
    public DoorState doorState;
    
    private Animator _buttonAnim;
    public Animator doorAnim;
    
    private float _doorTimer;
    public float doorTime = 2f;
    
    private void Awake()
    {
        _buttonAnim = GetComponent<Animator>();
        doorState = DoorState.Closed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            _buttonAnim.SetTrigger("Pushed");
            if (doorState.Equals(DoorState.Closed))
            {
                doorAnim.SetTrigger("Abrir");
                _doorTimer = doorTime;
                doorState = DoorState.Open;
            }else if (doorState.Equals(DoorState.Open))
            {
                _doorTimer = doorTime;
            }
        }
    }

    private void Update()
    {
        if (doorState.Equals(DoorState.Open) && _doorTimer <= 0)
        {
            doorAnim.SetTrigger("Cerrar");
            doorState = DoorState.Closed;
        }
        else if(doorState == DoorState.Open)
        {
            _doorTimer -= Time.deltaTime;
        }
}
}
