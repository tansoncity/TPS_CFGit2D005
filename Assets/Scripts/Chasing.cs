using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Chasing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _chasingRadius = 5f;
    [SerializeField] private float _reachingRadius = 1f;

    private float TargetDistance => Vector3.Distance(transform.position, _target.position);

    public void UpdateChasing() => _navMeshAgent.SetDestination(_target.position);

    public void StopChasing() => _navMeshAgent.ResetPath();

    public bool IsInChasingRange() => TargetDistance <= _chasingRadius;

    public bool IsReached => TargetDistance <= _reachingRadius;
}
