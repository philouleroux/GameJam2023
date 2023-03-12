using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    RoomObject currentRoom;
    public Torch torch;
    public bool HasTorch { get; set; }  

    void OnEnable()
    {
        GameManager.instance.Player = this;
        HasTorch = true;
        currentRoom.lightSources.Add(torch);
    }

    void Update()
    {
        
    }

    public void setRoom (RoomObject p_room) 
    {
        currentRoom = p_room;
    }

    public RoomObject getRoom()
    {
        return currentRoom;
    }
}
