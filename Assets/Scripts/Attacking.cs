using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private Health _targetHealth;

    private void Start() => StopAttacking();

    public void StartAttacking() => enabled = true;

    public void StopAttacking() => enabled = false;

    public void OnHandDown() => Attack();
    
    private void Attack()
    {
        if (_targetHealth != null)
        {
            _targetHealth.TakeDamage(_damage);
        }
    }
}
