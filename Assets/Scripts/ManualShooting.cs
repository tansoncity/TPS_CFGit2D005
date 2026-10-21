using UnityEngine;
using UnityEngine.InputSystem;

public class ManualShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private Transform _firingPoint;
    [SerializeField] private AudioSource _shootingSound;

    private InputAction _attackAction;

    private void Start()
    {
        _attackAction = InputSystem.actions["Attack"];
        _attackAction.Enable();
    }

    private void Update()
    {
        if (_attackAction.triggered)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab,
            _firingPoint.position, _firingPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity =
            _firingPoint.forward * _bulletSpeed;
        _shootingSound.Play();
    }
}
