using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    uint currentRoom;
    void Start()
    {
        currentRoom = 3;
    }

    void Update()
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
