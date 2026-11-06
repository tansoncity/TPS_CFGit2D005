using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;
using System.Collections.Generic;

public class GameFlow : MonoBehaviour
{
    public List<GameObject> _eventListeners;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private EnemyManager _enemyManager;

    public static UnityAction GameOver;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        _victoryPanel.SetActive(false);
        _playerHealth.Dead.AddListener(OnPlayerDead);
        _enemyManager.AllEnemyCleared.AddListener(OnAllEnemyCleared);
    }

    private void OnAllEnemyCleared()
    {
        //CustomEvent.Trigger(gameObject, "AllEnemyCleared");
    }

    private void OnDestroy()
    {
        _playerHealth.Dead.RemoveListener(OnPlayerDead);
        _enemyManager.AllEnemyCleared.RemoveListener(OnAllEnemyCleared);
    }

    public void OnPlayerDead() => CustomEvent.Trigger(gameObject, "PlayerDead");

    public void TriggerGameOver()
    {
        _gameOverPanel.SetActive(true);
        GameOver?.Invoke();
    }

    public void OnVictory() {
         _victoryPanel.SetActive(true);
         foreach (var listener in _eventListeners)
         {
             listener.BroadcastMessage("OnVictory", SendMessageOptions.DontRequireReceiver);
         }
    }
}
