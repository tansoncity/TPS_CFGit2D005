using UnityEngine;

public class GrenadeLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 20f;
    [SerializeField] private Transform _firingPoint;
    [SerializeField] private AudioSource _shootingSound;

    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab,
            _firingPoint.position, _firingPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity =
            _firingPoint.forward * _bulletSpeed;
        _shootingSound.Play();
    }
}
