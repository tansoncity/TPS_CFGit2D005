using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _filledImage;
    [SerializeField] private Health _health;
    [SerializeField] private bool _alwaysVisible;
    [SerializeField] private float _visibleDuration = 2f;

    private void Start()
    {
        UpdateHealthValue();
        _health.HealthChanged.AddListener(UpdateHealthValue);
        Hide();
        _health.DamageTaken.AddListener(Show);
    }

    private void OnDestroy() 
    {
        _health.HealthChanged.RemoveListener(UpdateHealthValue);
        _health.DamageTaken.RemoveListener(Show);
    }

    private void UpdateHealthValue() 
        => _filledImage.fillAmount = (float)_health.CurrentHealth / _health.MaxHealth;

    public void Show()
    {
        gameObject.SetActive(true);
        if (!_alwaysVisible)
        {
            CancelInvoke();
            Invoke(nameof(Hide), _visibleDuration);
        }
    }

    public void Hide() => gameObject.SetActive(false);
}
