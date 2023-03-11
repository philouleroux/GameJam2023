using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected GameObject playerObj;

    protected BehaviourTree behaviourTree;
    protected GameObject destination;
    protected Animator anim;
    protected NavMeshAgent agent;
    protected bool endIdleTime = false;
    protected bool success = false;
    protected float patrolIdleTime = 2f;

    public enum ActionState
    {
        IDLE,
        WORKING
    };
    protected ActionState state = ActionState.IDLE;

    Node.Status treeStatus;

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        behaviourTree = new BehaviourTree();
        treeStatus = Node.Status.RUNNING;
    }

    protected void SetNPCRotation()
    {
        transform.rotation = Quaternion.RotateTowards(
        transform.rotation,
        Quaternion.LookRotation(playerObj.transform.position - transform.position, Vector3.up),
        4f);
    }

    protected virtual Node.Status SeePlayer()
    {
        state = ActionState.IDLE;
        if (Vector3.Distance(playerObj.transform.position, transform.position) < 20)
        {
            return Node.Status.SUCCESS;
        }
        else
        {
            return Node.Status.FAILURE;
        }
    }

    protected Node.Status GoToPlayer()
    {
        if (state == ActionState.IDLE && Vector3.Distance(playerObj.transform.position, transform.position) >= 4)
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                anim.SetTrigger("Walk");

            agent.isStopped = false;
            agent.SetDestination(playerObj.transform.position);
            state = ActionState.WORKING;
        }
        else if (state == ActionState.WORKING)
        {
            agent.isStopped = false;
            agent.SetDestination(playerObj.transform.position);
        }
        if (Vector3.Distance(playerObj.transform.position, transform.position) >= 20)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        if (Vector3.Distance(playerObj.transform.position, transform.position) < 4)
        {
            agent.isStopped = true;
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }

    protected IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        endIdleTime = true;
    }

    protected virtual Node.Status PatrolIdleTime()
    {
        if (state == ActionState.IDLE)
        {
            agent.isStopped = true;
            state = ActionState.WORKING;
            StartCoroutine(WaitTime(patrolIdleTime));
        }
        else if (endIdleTime)
        {
            state = ActionState.IDLE;
            endIdleTime = false;
            success = true;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
}
