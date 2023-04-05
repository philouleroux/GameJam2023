using UnityEngine.AI;
using UnityEngine;
public class EnemyFollowPlayerState : EnemyBaseState
{
    Transform torchTransform;
    public EnemyFollowPlayerState(NavMeshAgent navMeshAgent, Transform playerTransform)
    {
        base.navMeshAgent = navMeshAgent;
        this.torchTransform = playerTransform;
    }

    public override void EnterState(EnemyStateManager context)
    {
        //Something need to happen here?
        navMeshAgent.isStopped = false;
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
        navMeshAgent.SetDestination(torchTransform.GetComponentInChildren<Torch>().transform.position);
    }
}
