using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjetoMovible : MonoBehaviour
{
    public Transform puntoInicio;
    public Transform puntoFin;
    
    private Vector3 _nextWaypoint;
    private Rigidbody _rb;

    private float _timer;
    public float tiempoQuieto;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _nextWaypoint = puntoFin.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == puntoInicio.position)
        {
            _nextWaypoint = puntoFin.position;
            _timer = tiempoQuieto;
        }
        else if (transform.position == puntoFin.position)
        {
            _nextWaypoint = puntoInicio.position;
            _timer = tiempoQuieto;
        }
        
        if(_timer <= 0)
            _rb.Move(_nextWaypoint, Quaternion.identity);
        else if (transform.position == _nextWaypoint)
            _timer -= Time.deltaTime;
    }
}
