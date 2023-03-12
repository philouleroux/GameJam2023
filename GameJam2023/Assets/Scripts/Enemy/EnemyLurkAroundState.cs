using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;

public class EnemyLurkAroundState : EnemyBaseState
{
    public struct lightStruc
    {
        public bool isLit { get; set; }
        public LightSource light { get; set; }

        public lightStruc(bool p_isLit, LightSource p_lightSource)
        {
            this.isLit = false;
            this.light = p_lightSource;
        }
    }

    lightStruc lBraziere = new lightStruc(false, null);
    lightStruc lAltar = new lightStruc(false, null);
    lightStruc lTorch = new lightStruc(false, null);

    bool isChassingTorch = false;
    public EnemyLurkAroundState(NavMeshAgent navMeshAgent)
    {
        base.navMeshAgent = navMeshAgent;
    }
    public override void EnterState(EnemyStateManager context)
    {
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
                    else
                    {
                        lBraziere.isLit = false;
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
                    else
                    {
                        lAltar.isLit = false;
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
                    else
                    {
                        lTorch.isLit = false;
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
                    isChassingTorch = false;
                }
                else if (lAltar.isLit)
                {
                    navMeshAgent.SetDestination(lAltar.light.transform.position);
                    isChassingTorch = false;
                }
                else if (lTorch.isLit)
                {
                    isChassingTorch = true;
                }
                else
                {
                    isChassingTorch = false;
                }
            }
        }
        else
        {
            isChassingTorch = false;
        }
    }

    public override void OnCollision(EnemyStateManager context, Collision collision)
    {

    }

    public override void UpdateState(EnemyStateManager context)
    {
        //IsPlayer/LightInRoom
        if (isChassingTorch)
        {
            navMeshAgent.SetDestination(lTorch.light.transform.position);
        }        
    }

  
}
