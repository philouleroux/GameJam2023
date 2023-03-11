using UnityEngine.AI;
using UnityEngine;

public abstract class EnemyBaseState
{
    protected NavMeshAgent navMeshAgent;

    public abstract void UpdateState(EnemyStateManager context);
    public abstract void EnterState(EnemyStateManager context);
    public abstract void OnCollision(EnemyStateManager context, Collision collision);
}
