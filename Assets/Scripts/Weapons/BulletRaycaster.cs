using UnityEngine;
using Unity.Cinemachine;

public class BulletRaycaster : MonoBehaviour
{
    [SerializeField] private Transform _aimingCamera;
    [SerializeField] private Transform _hitMarkerPrefab;
    [SerializeField] private AudioSource _shootAudio;
    [SerializeField] private int _damage;

    public void Shoot()
    {
        var aimingRay = new Ray(_aimingCamera.position, _aimingCamera.forward);
        if (Physics.Raycast(aimingRay, out var hitInfo))
        {
            OnHit(hitInfo);
        }
        _shootAudio.Play();
    }

    private void OnHit(RaycastHit hitInfo)
    {
        var lookDirection = Quaternion.LookRotation(hitInfo.normal);
        var marker = Instantiate(_hitMarkerPrefab, hitInfo.point, lookDirection);
        marker.SetParent(hitInfo.collider.transform, worldPositionStays: true);

        var health = hitInfo.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(_damage);
        }
    }
}
