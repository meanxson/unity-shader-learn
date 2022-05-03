using UnityEngine;
using UnityEngine.AI;

namespace Client.Scripts.Learn.Enemy.States
{
    public abstract class BaseEnemyState
    {
        protected Animator Animator;
        protected IEnemySwitchState SwitchState;

        protected BaseEnemyState(Animator animator, IEnemySwitchState switchState)
        {
            Animator = animator;
            SwitchState = switchState;
        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void Execute();
    }
}