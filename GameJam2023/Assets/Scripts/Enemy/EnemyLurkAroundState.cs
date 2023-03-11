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
        //brazier, hotel, torch
        navMeshAgent.SetDestination(context.transform.position);
        if (context.currentRoom.lightSources.Count != 0)
        {
            foreach (LightSource light in context.currentRoom.lightSources)
            {
                if (light.GetComponent<Brazier>() != null)
                {
                    if (light.IsLit)
                    {
                        Debug.Log(context.currentRoom.name + ": Brazier is Lit");
                    }
                }
                else if (light.GetComponent<Altar>() != null)
                {
                    if (light.IsLit)
                    {
                        Debug.Log(context.currentRoom.name + ": Alter is Lit");
                    }
                }
                else if (light.GetComponent<Torch>() != null)
                {
                    if (light.IsLit)
                    {
                        Debug.Log(context.currentRoom.name + ": Torch is Lit");
                    }
                }
            }
        }
    }

    public override void OnCollision(EnemyStateManager context, Collision collision)
    {

    }

    public override void UpdateState(EnemyStateManager context)
    {
        //IsPlayer/LightInRoom
        
    }
}
