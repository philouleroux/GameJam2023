using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public RoomObject currentRoom;
    public Torch torch;
    public bool HasTorch { get; set; }
    public Animator Animator { get; private set; }
    public bool IsGrabbing { get; set; }
    public bool IsPraying { get; set; }

    void Start()
    {
        Animator = GetComponent<Animator>();
        GameManager.instance.Player = this;
        HasTorch = true;
        currentRoom.lightSources.Add(torch);
        InputHandler.Subscribe(KeyAction.LEFT_CLICK, AttractEnemies);
    }

    private void AttractEnemies(InputAction.CallbackContext c)
    {
        if (HasTorch)
        {
            Animator.SetTrigger("Attract");
            EventManager<RoomObject>.PublishParam(GameEventType.PLAYER_ATTRACT, currentRoom);
            InputHandler.Unsubscribe(KeyAction.LEFT_CLICK);
            StartCoroutine(ChasingCoroutine());
        }
    }

    public void SetRoom (RoomObject p_room) 
    {
        currentRoom = p_room;
    }

    public RoomObject GetRoom()
    {
        return currentRoom;
    }

    private IEnumerator ChasingCoroutine()
    {
        yield return new WaitForSeconds(7f);
        EventManager.Publish(GameEventType.LIGHT_LIT);
        InputHandler.Subscribe(KeyAction.LEFT_CLICK, AttractEnemies);
    }

    public void ResetPrayerAnim()
    {
        Animator.SetTrigger("Kneeling");
        EventManager<string>.PublishParam(GameEventType.ANIM_OVER, "Prayer");
    }

    public void ResetKneelingAnim()
    {
        Animator.SetTrigger("Prayer");
    }
    
    public void ResetDropTorchAnim()
    {
        EventManager<string>.PublishParam(GameEventType.ANIM_OVER, "DropTorch");
    }
    
    public void ResetGrabIdleAnim()
    {

    }
    
    public void ResetGrabPullAnim()
    {

    }

    public void ResetLightBrazierAnim()
    {
        EventManager<string>.PublishParam(GameEventType.ANIM_OVER, "LightBrazier");
    }
}
