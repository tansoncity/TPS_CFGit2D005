using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum ChasingState
{
    Lost,
    Chasing,
    Reached
}

public class Chasing : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _chasingRadius = 5f;
    [SerializeField] private float _reachingRadius = 1f;

    public UnityEvent TargetReached;
    public UnityEvent TargetLost;
    public UnityEvent ChasingStarted;

    private ChasingState _currentState = ChasingState.Lost;

    private void Update()
    {
        if (_target == null) return;

        var distance = Vector3.Distance(transform.position, _target.position);
        if (distance > _chasingRadius)
        {
            SwitchTo(ChasingState.Lost);
            _navMeshAgent.ResetPath();
        }
        else if (distance > _reachingRadius)
        {
            SwitchTo(ChasingState.Chasing);
            _navMeshAgent.SetDestination(_target.position);
        }
        else
        {
            SwitchTo(ChasingState.Reached);
            _navMeshAgent.ResetPath();
        }
    }

    private void SwitchTo(ChasingState newState)
    {
        if (_currentState == newState) return;
        _currentState = newState;
        switch (newState)
        {
            case ChasingState.Lost:
                TargetLost?.Invoke();
                break;
            case ChasingState.Chasing:
                ChasingStarted?.Invoke();
                break;
            case ChasingState.Reached:
                TargetReached?.Invoke();
                break;
        }
    }
}
