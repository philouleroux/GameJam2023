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

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.GetComponent<Player>().setRoom(newRoom);
        }
    }
}
