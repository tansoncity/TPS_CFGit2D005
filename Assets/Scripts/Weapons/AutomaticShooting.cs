using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class AutomaticShooting : MonoBehaviour
{
    [SerializeField] private float _coolDown;

    public UnityEvent BulletShot;

    private float _lastShotTime;

    private InputAction _attackAction;

    private void Start()
    {
        _attackAction = InputSystem.actions["Attack"];
        _attackAction.Enable();
    }

    private void Update()
    {
        if (_attackAction.IsPressed() && _lastShotTime + _coolDown <= Time.time)
        {
            BulletShot.Invoke();
            _lastShotTime = Time.time;
        }
    }
}
