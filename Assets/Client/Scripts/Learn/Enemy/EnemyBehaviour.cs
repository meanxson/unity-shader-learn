using System.Collections.Generic;
using System.Linq;
using Client.Scripts.Learn.Enemy;
using Client.Scripts.Learn.Enemy.States;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour, IEnemySwitchState
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;

    private NavMeshAgent _agent;
    private List<BaseEnemyState> _states;
    private BaseEnemyState _currentState;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _states = new List<BaseEnemyState>
        {
            new EnemyFollowState(_animator, this, _agent, _speed, _stopDistance, 
                FindObjectOfType<PlayerBehaviour>())
        };

        _currentState = _states[0];
        _currentState.Start();
        _currentState.Execute();
    }


    public void SwitchState<T>() where T : BaseEnemyState
    {
        var state = _states.FirstOrDefault(enemyState => enemyState is T);
        _currentState.Stop();
        _currentState = state;

        if (ReferenceEquals(_currentState, null))
            return;
        
        _currentState.Start();
        _currentState.Execute();
    }
}