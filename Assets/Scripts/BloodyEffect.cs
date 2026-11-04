using UnityEngine;

public class BloodyEffect : MonoBehaviour
{
    [SerializeField] private float _duration = 0.2f;

    private void Start() => Hide();

    public void Show()
    {
        gameObject.SetActive(true);
        Invoke(nameof(Hide), _duration);
    }

    public void Hide() => gameObject.SetActive(false);
}