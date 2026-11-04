using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint = 100;

    public UnityEvent DamageTaken;

    public UnityEvent Dead;

    private int _healthPoint;

    public bool IsDead => _healthPoint <= 0;

    private void Start() => _healthPoint = _maxHealthPoint;

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        _healthPoint -= damage;
        DamageTaken?.Invoke();
        
        if (IsDead)
        {
            Die();
        }
    }

    private void Die() 
    {
        Dead?.Invoke();
        gameObject.BroadcastMessage("OnDead", SendMessageOptions.DontRequireReceiver);
    }
}
