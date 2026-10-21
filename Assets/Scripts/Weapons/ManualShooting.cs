using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ManualShooting : MonoBehaviour
{
    public UnityEvent BulletShot;

    private InputAction _attackAction;

    private void Start()
    {
        _attackAction = InputSystem.actions["Attack"];
        _attackAction.Enable();
    }

    private void Update()
    {
        if (_attackAction.triggered)
        {
            BulletShot.Invoke();
        }
    }
}
