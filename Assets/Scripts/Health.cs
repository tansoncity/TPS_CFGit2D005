using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint = 100;

    public UnityEvent DamageTaken;
    public UnityEvent HealthChanged;

    public UnityEvent Dead;

    private int _healthPoint;

    public int CurrentHealth {
        get => _healthPoint;
        set
        {
            _healthPoint = value;
            HealthChanged?.Invoke();
        }
    }

    public int MaxHealth => _maxHealthPoint;

    public bool IsDead => _healthPoint <= 0;

    private void Start() => CurrentHealth = _maxHealthPoint;

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        CurrentHealth -= damage;
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
