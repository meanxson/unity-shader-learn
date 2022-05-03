using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Client.Scripts.Learn.Enemy.States
{
    public class EnemyFollowState : BaseEnemyState
    {
        public NavMeshAgent Agent { get; private set; }
        public Vector3 Target { get; private set; }

        private readonly PlayerBehaviour _currentTarget;
        private readonly float _speed;
        private readonly float _stopDistance;


        public EnemyFollowState(Animator animator, IEnemySwitchState switchState, NavMeshAgent agent, float speed,
            float stopDistance, PlayerBehaviour currentTarget) : base(animator, switchState)
        {
            Agent = agent;
            _speed = speed;
            _stopDistance = stopDistance;
            _currentTarget = currentTarget;
        }

        public override void Start()
        {
            Agent.isStopped = false;
            Agent.speed = _speed;
            Agent.stoppingDistance = _stopDistance;
        }

        public override void Stop()
        {
            Agent.isStopped = true;
        }

        public override async void Execute()
        {
            var target = _currentTarget;
            while (true)
            {
                if (!ReferenceEquals(target, null)) Target = target.transform.position;

                await Task.Delay(1);

                if (Agent.isOnNavMesh) Agent.SetDestination(Target);
                else return;
            }
        }
    }
}