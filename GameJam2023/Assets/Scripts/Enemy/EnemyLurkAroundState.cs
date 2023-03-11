using UnityEngine;
using UnityEngine.AI;

public class EnemyLurkAroundState : EnemyBaseState
{
    public struct lightStruc
    {
        public bool isLit { get; set; }
        public LightSource light { get; set; }
    }
    public EnemyLurkAroundState(NavMeshAgent navMeshAgent)
    {
        base.navMeshAgent = navMeshAgent;
    }
    public override void EnterState(EnemyStateManager context)
    {
        lightStruc lBraziere = new lightStruc();
        lightStruc lAltar = new lightStruc();
        lightStruc lTorch = new lightStruc();
                
        lBraziere.isLit = false;
        lAltar.isLit = false;
        lTorch.isLit = false;

        //brazier, hotel, torch
        //navMeshAgent.SetDestination(context.transform.position);
        if (context.currentRoom.lightSources.Count != 0)
        {
            foreach (LightSource light in context.currentRoom.lightSources)
            {
                if (light.GetComponent<Brazier>() != null)
                {
                    if (light.IsLit)
                    {
                        Debug.Log(context.currentRoom.name + ": Brazier is Lit");
                        lBraziere.isLit = true;
                        lBraziere.light = light;
                    }
                }
                else if (light.GetComponent<Altar>() != null)
                {
                    if (light.IsLit)
                    {
                        Debug.Log(context.currentRoom.name + ": Alter is Lit");
                        lAltar.isLit = true;
                        lAltar.light = light;
                    }
                }
                else if (light.GetComponent<Torch>() != null)
                {
                    if (light.IsLit)
                    {
                        Debug.Log(context.currentRoom.name + ": Torch is Lit");
                        lTorch.isLit = true;
                        lTorch.light = light;
                    }
                }
            }

            if (!lBraziere.isLit && !lAltar.isLit && !lTorch.isLit)
            {
                navMeshAgent.SetDestination(context.transform.position);
            }
            else
            {
                if (lBraziere.isLit)
                {
                    navMeshAgent.SetDestination(lBraziere.light.transform.position);
                }
                else if (lAltar.isLit)
                {
                    navMeshAgent.SetDestination(lAltar.light.transform.position);
                }
                else if (lTorch.isLit)
                {
                    navMeshAgent.SetDestination(lTorch.light.transform.position);
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
