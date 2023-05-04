using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _nma;

    private int _animState;
    private float _shootInterval;

    private int _actualWaypoint;
    public Transform[] waypoints;
    public Transform waypointBoton;
    public PuertaController puertaController;
    
    private float dmg = 5f;                                     

    private void Awake()
    {
        _nma = GetComponent<NavMeshAgent>();
        _actualWaypoint = 0;
        _nma.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (!_nma.pathPending && _nma.hasPath && _nma.remainingDistance < .5f)
        {
            _actualWaypoint++;
            if (_actualWaypoint >= waypoints.Length)
                _actualWaypoint = 0;
            Transform destino = waypoints[_actualWaypoint];
            if (destino == waypointBoton && puertaController.doorState == DoorState.Open)
            {
                _actualWaypoint++;
                destino = waypoints[_actualWaypoint];
            }
            _nma.SetDestination(destino.position);
        }
    }
    
    

    private bool IsMoving()
    {
        return _nma.velocity != Vector3.zero;
    }
}
