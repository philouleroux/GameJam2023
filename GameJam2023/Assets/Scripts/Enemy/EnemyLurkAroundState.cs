using UnityEngine;
using UnityEngine.AI;

public class EnemyLurkAroundState : EnemyBaseState
{

    public EnemyLurkAroundState(NavMeshAgent navMeshAgent)
    {
        base.navMeshAgent = navMeshAgent;
    }
    public override void EnterState(EnemyStateManager context)
    {
        navMeshAgent.SetDestination(context.transform.position);
    }

    public override void OnCollision(EnemyStateManager context, Collision collision)
    {

    }

    public override void UpdateState(EnemyStateManager context)
    {
        //IsPlayer/LightInRoom
    }
}
