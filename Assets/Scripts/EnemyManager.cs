using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;

    public UnityEvent AllEnemyCleared;

    private int _totalEnemy;
    private int _remainingEnemy;

    public int RemainingEnemy => _remainingEnemy;

    private void Start()
    {
        _totalEnemy = _enemies.Length;
        _remainingEnemy = _totalEnemy;
        foreach (var enemy in _enemies)
        {
            if (enemy.TryGetComponent<Health>(out var health))
            {
                health.Dead.AddListener(OnEnemyDead);
            }
        }
    }
    
    private void OnEnemyDead()
    {
        _remainingEnemy--;
        if (_remainingEnemy <= 0)
        {
            AllEnemyCleared?.Invoke();
        }
    }
}
