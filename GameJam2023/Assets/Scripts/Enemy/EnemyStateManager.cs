using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField]
    public RoomObject currentRoom;

    EnemyBaseState currentState;

    public Animator anim;
    public EnemyAttackLightState attackLightState { get; private set; }
    public EnemyFollowPlayerState followPlayerState { get; private set; }
    public EnemyLurkAroundState lurkAroundState { get; private set; }
    public EnemyGoToLightState goToLightState { get; private set; }

    private NavMeshAgent navMeshAgent;

    //public Transform transformLight;

    [SerializeField] Transform playerTransform;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        attackLightState = new EnemyAttackLightState(navMeshAgent);
        followPlayerState = new EnemyFollowPlayerState(navMeshAgent, playerTransform);
        lurkAroundState = new EnemyLurkAroundState(navMeshAgent);
        goToLightState = new EnemyGoToLightState(navMeshAgent);
        EventManager.Subscribe(GameEventType.LIGHT_LIT, ChangeToLurk);
        EventManager<RoomObject>.SubscribeParam(GameEventType.PLAYER_ATTRACT, GoToPlayer);
    }

    private void GoToPlayer(RoomObject playerRoom)
    {
        if (currentRoom == playerRoom)
        {
            SwitchState(followPlayerState);
        }
    }

    private void Start()
    {
        currentState = null;
        currentState = lurkAroundState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        //Debug.Log(nameof(currentState));
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        currentState = newState;
        anim.SetTrigger("lurkAroundState");
        currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollision(this, collision);
    }

    private void ChangeToLurk()
    {
        SwitchState(lurkAroundState);
    }
}
