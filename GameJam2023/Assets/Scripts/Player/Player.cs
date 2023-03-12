using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    RoomObject currentRoom;
    public Torch torch;
    public bool HasTorch { get; set; }
    public Animator Animator { get; private set; }
    public bool IsGrabbing { get; set; }

    void Start()
    {
        Animator = GetComponent<Animator>();
        GameManager.instance.Player = this;
        HasTorch = true;
        currentRoom.lightSources.Add(torch);
    }

    void Update()
    {
        
    }

    public void SetRoom (RoomObject p_room) 
    {
        currentRoom = p_room;
    }

    public RoomObject GetRoom()
    {
        return currentRoom;
    }

    public void ResetWalkAnim()
    {

    }
    
    public void ResetWalkNoTorchAnim()
    {

    }
    
    public void ResetIdleAnim()
    {

    }
    
    public void ResetAttractAnim()
    {

    }

    public void ResetPrayerAnim()
    {
        EventManager<string>.PublishParam(GameEventType.ANIM_OVER, "Prayer");
    }

    public void ResetBurnAnim()
    {

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
