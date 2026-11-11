using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private const float DefaultVerticalSpeed = -1;

    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 7f;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;

    private Vector2 _inputDirection;
    private Vector2 _animDirection;
    private Vector3 _velocity;

    private InputAction _moveAction;
    private InputAction _jumpAction;

    private void Start()
    {
        _moveAction = InputSystem.actions["Move"];
        _moveAction.Enable();
        _jumpAction= InputSystem.actions["Jump"];
        _jumpAction.Enable();
    }

    private void Update()
    {
        UpdateNavigating();
        UpdateJumping();
        UpdateFalling();
        _characterController.Move(_velocity * Time.deltaTime);
        UpdateAnimator();
    }

    private void UpdateNavigating()
    {
        _inputDirection = _moveAction.ReadValue<Vector2>();
        var direction = transform.right * _inputDirection.x + transform.forward * _inputDirection.y;
        direction = direction.normalized;
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

    private Vector2 _smoothVelocity;
    private void UpdateAnimator()
    {
        _animator.SetBool("IsMoving", _velocity.x != 0 || _velocity.z != 0);
        _animDirection.x = Mathf.SmoothDamp(
            _animDirection.x, _inputDirection.x, ref _smoothVelocity.x, 0.1f);
        _animDirection.y = Mathf.SmoothDamp(
            _animDirection.y, _inputDirection.y, ref _smoothVelocity.y, 0.1f);
        _animator.SetFloat("MoveX", _animDirection.x);
        _animator.SetFloat("MoveY", _animDirection.y);
    }

    private void OnDead() => StopAll();

    private void OnVictory() => StopAll();

    private void StopAll()
    {
        enabled = false;
        _characterController.enabled = false;
    }
}
