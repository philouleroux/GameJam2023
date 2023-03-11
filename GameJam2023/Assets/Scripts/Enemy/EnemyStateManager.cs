using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField]
    RoomObject currentRoom;

    EnemyBaseState currentState;
    public EnemyAttackLightState attackLightState { get; private set; }
    public EnemyFollowPlayerState followPlayerState { get; private set; }
    public EnemyLurkAroundState lurkAroundState { get; private set; }
    public EnemyGoToLightState goToLightState { get; private set; }

    private NavMeshAgent navMeshAgent;

    public Transform transformLight;

    [SerializeField] Transform playerTransform;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        attackLightState = new EnemyAttackLightState(navMeshAgent);
        followPlayerState = new EnemyFollowPlayerState(navMeshAgent, playerTransform);
        lurkAroundState = new EnemyLurkAroundState(navMeshAgent);
        goToLightState = new EnemyGoToLightState(navMeshAgent);
    }

    private void Start()
    {
        currentState = lurkAroundState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollision(this, collision);
    }
}
