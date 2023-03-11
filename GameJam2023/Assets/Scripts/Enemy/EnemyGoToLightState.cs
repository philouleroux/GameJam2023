using UnityEngine;
using UnityEngine.AI;

public class EnemyGoToLightState : EnemyBaseState
{
    public EnemyGoToLightState(NavMeshAgent navMeshAgent)
    {
        base.navMeshAgent = navMeshAgent;
    }

    public override void EnterState(EnemyStateManager context)
    {
        navMeshAgent.SetDestination(context.transformLight.position);
    }

    public override void OnCollision(EnemyStateManager context, Collision collision)
    {
        /* Faire comme ça, mais avec l'object Light
        
        PlayerMouvement player = collision.gameObject.GetComponent<PlayerMouvement>();
        if (player != null)
        {
            context.SwitchState(context.attackLightState);
        }
        */
    }

    public override void UpdateState(EnemyStateManager context)
    {
        throw new System.NotImplementedException();
    }
}
