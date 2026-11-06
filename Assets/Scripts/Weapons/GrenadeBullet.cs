using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private int _damage = 10;
    [SerializeField] private LayerMask _hitLayer;

    private void OnCollisionEnter(Collision _)
    {
        Explode();
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Explode()
    {
        List<Health> processed = new List<Health>();
        var victims = Physics.OverlapSphere(transform.position, _explosionRadius, _hitLayer);
        foreach (var victim in victims)
        {
            var health = victim.GetComponentInParent<Health>();
            if (health != null && !processed.Contains(health))
            {
                health.TakeDamage(_damage);
                processed.Add(health);
            }
            if (victim.attachedRigidbody != null)
            {
                victim.attachedRigidbody.AddExplosionForce(
                    _explosionForce, transform.position,
                    _explosionRadius, 1f, ForceMode.Impulse);
            }
        }
    }
}
