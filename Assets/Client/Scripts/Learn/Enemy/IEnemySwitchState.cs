using Client.Scripts.Learn.Enemy.States;

namespace Client.Scripts.Learn.Enemy
{
    public interface IEnemySwitchState
    {
        void SwitchState<T>() where T : BaseEnemyState;
    }
}