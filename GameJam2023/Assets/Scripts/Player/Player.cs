using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    uint currentRoom;
    private Collider blockCollider;

    void Awake()
    {
        currentRoom = 3;
        blockCollider = GetComponent<Collider>();

        InputHandler.Subscribe(KeyAction.LEFT_CLICK, Attract);
    }

    void Update()
    {
        
    }

    private void Attract(InputAction.CallbackContext context)
    {

    }

    public void setRoom (uint p_room) 
    {
        currentRoom = p_room;
    }

    public uint getRoom()
    {
        return currentRoom;
    }
}
