using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const float DefaultUpSpeed = -1;

    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private CharacterController _characterController;

    private Vector3 _velocity;
    private float _upSpeed = DefaultUpSpeed;

    private InputAction _moveInput;

    private void Start()
    {
        _moveInput = InputSystem.actions["Move"];
        _moveInput.Enable();
    }

    private void Update()
    {
        UpdateNavigating();
        UpdateFalling();
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void UpdateNavigating()
    {
        var moveInput = _moveInput.ReadValue<Vector2>();
        var direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        _velocity.x = direction.x * _walkSpeed;
        _velocity.z = direction.z * _walkSpeed;
    }

    private void UpdateFalling()
    {
        if (_characterController.isGrounded)
        {
            _upSpeed = DefaultUpSpeed;
        }
        else
        {
            _upSpeed += Physics.gravity.y * Time.deltaTime;
        }
        _velocity += _upSpeed * Vector3.up;
    }
}
