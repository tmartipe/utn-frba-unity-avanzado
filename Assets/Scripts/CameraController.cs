using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _angulo = 0;
    
    void Update()
    {
        _angulo -= Input.GetAxis("Mouse Y");
        _angulo = Mathf.Clamp(_angulo, -90, 90);
        var actualAngle = transform.eulerAngles;
        transform.eulerAngles = new Vector3(_angulo, actualAngle.y, actualAngle.z);
    }
}
