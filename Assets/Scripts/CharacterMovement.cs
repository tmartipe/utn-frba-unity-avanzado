using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float _rotAngle;
    private float _gravedad = 5f;
    [SerializeField] private float jumpForce = 2f;
    private CharacterController _controller;
    [SerializeField] private float speed;
    private Vector3 _movementDirection = Vector3.zero;
    
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        _movementDirection.x = Input.GetAxisRaw("Horizontal");
        _movementDirection.z = Input.GetAxisRaw("Vertical");
        if (_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            _movementDirection.y = jumpForce;
        else
            _movementDirection.y -= _gravedad * Time.deltaTime;
        _rotAngle = Input.GetAxis("Mouse X");
        transform.Rotate(0, _rotAngle, 0);
        _controller.Move(transform.TransformVector(_movementDirection * (speed * Time.deltaTime)));
    }
}
