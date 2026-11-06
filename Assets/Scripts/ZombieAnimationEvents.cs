using UnityEngine;
using UnityEngine.Events;

public class ZombieAnimationEvents : MonoBehaviour
{
    public UnityEvent OnHandDownEvent;

    public void OnHandDown() => OnHandDownEvent?.Invoke();
}
