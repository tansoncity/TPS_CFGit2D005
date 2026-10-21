using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
