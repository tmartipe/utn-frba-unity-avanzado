using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

[SuppressMessage("ReSharper", "PossibleLossOfFraction")]
public class DisparoFPS : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitEffect;
    private bool _canShoot;
    private float _timeUntilShoot;
    public float shootDelay;
    private Camera _mainCamera;
    public Slider slider;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        _canShoot = _timeUntilShoot <= 0;
        if (Input.GetKey(KeyCode.Mouse0) && _canShoot)
        {
            Shoot();
            _timeUntilShoot = shootDelay;
        }
        if (_timeUntilShoot > 0)
            _timeUntilShoot -= Time.deltaTime;
        slider.maxValue = shootDelay;
        slider.value = _timeUntilShoot;
    }

    void Shoot()
    {
        var shootingPosition = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
        bool choco;
        choco = Physics.Raycast(shootingPosition, transform.forward, out var hit);
        if (choco)
        {
            Instantiate(hitEffect, hit.point, Quaternion.identity);
            if (hit.transform.tag == "Target")
            {
                hit.transform.gameObject.GetComponent<Life>().ReceiveDamage(15f);
            }
        }
    }
}
