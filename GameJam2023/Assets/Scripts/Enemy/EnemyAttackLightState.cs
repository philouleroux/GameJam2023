using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackLightState : EnemyBaseState
{
    public EnemyAttackLightState(NavMeshAgent navMeshAgent)
    {
        base.navMeshAgent = navMeshAgent;
    }

    public override void EnterState(EnemyStateManager context)
    {
        //Stop
        //navMeshAgent.SetDestination(context.transform.position);
        navMeshAgent.isStopped = true;
        context.anim.SetTrigger("attackLightState");
    }

    public override void OnCollision(EnemyStateManager context, Collision collision)
    {

    }

    public override void UpdateState(EnemyStateManager context)
    {
        //DrainLight
    }
}
