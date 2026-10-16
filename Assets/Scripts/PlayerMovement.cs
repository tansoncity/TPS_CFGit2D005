using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const float DefaultVerticalSpeed = -1;

    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 7f;
    [SerializeField] private float _lookSpeed = 60f;
    [SerializeField] private CharacterController _characterController;

    private Vector3 _velocity;

    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _lookAction;

    private void Start()
    {
        _moveAction = InputSystem.actions["Move"];
        _moveAction.Enable();
        _jumpAction= InputSystem.actions["Jump"];
        _jumpAction.Enable();
        _lookAction = InputSystem.actions["Look"];
        _lookAction.Enable();
    }

    private void Update()
    {
        UpdateLooking();
        UpdateNavigating();
        UpdateJumping();
        UpdateFalling();
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void UpdateLooking()
    {
        var lookInput = _lookAction.ReadValue<Vector2>();
        var deltaAngle = lookInput.x * _lookSpeed * Time.deltaTime;
        transform.Rotate(0, deltaAngle, 0);
    }

    private void UpdateNavigating()
    {
        var moveInput = _moveAction.ReadValue<Vector2>();
        var direction = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        _velocity.x = direction.x * _walkSpeed;
        _velocity.z = direction.z * _walkSpeed;
    }

    private void UpdateJumping()
    {
        if (_jumpAction.triggered && _characterController.isGrounded)
        {
            _velocity.y = _jumpSpeed;
        }
    }

    private void UpdateFalling()
    {
        if (_velocity.y < 0 && _characterController.isGrounded)
        {
            _velocity.y = DefaultVerticalSpeed;
        }
        else
        {
            _velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }
}
