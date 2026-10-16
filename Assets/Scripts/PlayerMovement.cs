using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 5f;
    private InputAction _moveInput;

    private void Start()
    {
        _moveInput = InputSystem.actions["Move"];
        _moveInput.Enable();
    }

    private void Update()
    {
        var moveInput = _moveInput.ReadValue<Vector2>();
        var direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        transform.Translate(_walkSpeed * Time.deltaTime * direction);
    }
}
