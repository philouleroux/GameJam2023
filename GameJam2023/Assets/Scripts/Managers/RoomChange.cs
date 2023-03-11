using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomChange : MonoBehaviour
{
    // Start is called before the first frame update
    public uint newRoom;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.GetComponent<Player>().getRoom() != newRoom)
            {
                player.GetComponent<Player>().setRoom(newRoom);
                Debug.Log("newRoom: " + newRoom.ToString());
            }
        }
    }
}
