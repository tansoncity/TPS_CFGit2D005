using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnCollisionEnter(Collision _)
    {
        Explode();
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Explode()
    {
        var victims = Physics.OverlapSphere(
            transform.position, _explosionRadius);
        foreach (var victim in victims)
        {
            if (victim.attachedRigidbody != null)
            {
                victim.attachedRigidbody.AddExplosionForce(
                    _explosionForce, transform.position,
                    _explosionRadius, 0f, ForceMode.Impulse);
            }
        }
    }
}
