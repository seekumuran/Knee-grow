using UnityEngine;

public class AttackState : BaseState
{
    public AttackState(EnemyStateMachine machine)
        : base(machine)
    {

    }

    public override void Enter()
    {
        Debug.Log("Enemy Attack");
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {

    }
}
