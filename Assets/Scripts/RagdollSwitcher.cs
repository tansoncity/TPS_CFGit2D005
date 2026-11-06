using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigids;
    [SerializeField] private Animator _animator;

    [ContextMenu("Collect Rigidbodies")]
    private void CollectRigidbodies() => _rigids = GetComponentsInChildren<Rigidbody>();

    private void Start() => DisableRagdoll();

    public void OnDead() => EnableRagdoll();
    
    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll()
    {
        foreach (var rigid in _rigids)
        {
            rigid.isKinematic = false;
        }
        if (_animator != null)
        {
            _animator.enabled = false;
        }
    }
    
    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll()
    {
        foreach (var rigid in _rigids)
        {
            rigid.isKinematic = true;
        }
        if (_animator != null)
        {
            _animator.enabled = true;
        }
    }
}
