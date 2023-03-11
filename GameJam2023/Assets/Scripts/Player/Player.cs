using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    RoomObject currentRoom;

    public Torch torch;
    void Start()
    {
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
