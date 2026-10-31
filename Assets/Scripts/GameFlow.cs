using UnityEngine;
using UnityEngine.Events;
using Unity.VisualScripting;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private Health _playerHealth;

    public static UnityAction GameOver;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        _victoryPanel.SetActive(false);
        _playerHealth.Dead.AddListener(OnPlayerDead);

    }

    private void OnDestroy() => _playerHealth.Dead.RemoveListener(OnPlayerDead);

    public void OnPlayerDead() => CustomEvent.Trigger(gameObject, "PlayerDead");

    public void TriggerGameOver()
    {
        _gameOverPanel.SetActive(true);
        GameOver?.Invoke();
    }

    public void OnVictory() => _victoryPanel.SetActive(true);
}
