using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private BaseState currentState;

    public IdleState idleState;

    public ChaseState chaseState;

    public AttackState attackState;

    void Start()
    {
        idleState = new IdleState(this);

        chaseState = new ChaseState(this);

        attackState = new AttackState(this);

        ChangeState(idleState);
    }

    void Update()
    {
        currentState?.Tick();
    }

    public void ChangeState(BaseState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }
}
