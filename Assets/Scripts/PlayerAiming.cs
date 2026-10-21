using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _lookSpeed = 60f;
    [SerializeField] private float _minPitch = -90f;
    [SerializeField] private float _maxPitch = 90f;

    private InputAction _lookAction;
    private float _pitch;

    private void Start()
    {
        _lookAction = InputSystem.actions["Look"];
        _lookAction.Enable();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
#if UNITY_EDITOR

        if (Time.time < 1f) return;
#endif
        var lookInput = _lookAction.ReadValue<Vector2>();
        UpdateYaw(lookInput.x);
        UpdatePitch(lookInput.y);
    }

    private void UpdateYaw(float horizontalInput)
    {
        var deltaAngle = horizontalInput * _lookSpeed * Time.deltaTime;
        transform.Rotate(0, deltaAngle, 0);
    }

    private void UpdatePitch(float verticalInput)
    {
        var deltaAngle = -verticalInput * _lookSpeed * Time.deltaTime;

        _pitch = Mathf.Clamp(_pitch + deltaAngle, _minPitch, _maxPitch);
        _cameraTarget.localEulerAngles = new Vector3(_pitch, 0, 0);
    }
}
