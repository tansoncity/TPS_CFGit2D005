using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private float _attackInterval = 1f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private Health _targetHealth;

    private float _lastAttackTime;

    private void Start() => StopAttacking();

    public void StartAttacking() => enabled = true;

    public void StopAttacking() => enabled = false;

    private void Update()
    {
        if (Time.time - _lastAttackTime < _attackInterval) return;

        _lastAttackTime = Time.time;    
        Attack();
    }

    private void Attack()
    {
        print("Attacking!");
        if (_targetHealth != null)
        {
            _targetHealth.TakeDamage(_damage);
        }
    }
}
