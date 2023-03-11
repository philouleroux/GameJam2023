using UnityEngine.AI;
using UnityEngine;
public class EnemyFollowPlayerState : EnemyBaseState
{
    Transform playerTransform;
    public EnemyFollowPlayerState(NavMeshAgent navMeshAgent, Transform playerTransform)
    {
        base.navMeshAgent = navMeshAgent;
        this.playerTransform = playerTransform;
    }

    public override void EnterState(EnemyStateManager context)
    {
        //Something need to happen here?
    }

    public override void OnCollision(EnemyStateManager context, Collision collision)
    {
        PlayerMouvement player = collision.gameObject.GetComponent<PlayerMouvement>();
        if (player != null)
        {
            context.SwitchState(context.attackLightState);
        }
    }

    public override void UpdateState(EnemyStateManager context)
    {
        navMeshAgent.SetDestination(playerTransform.position);

    }
}
