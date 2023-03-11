using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomChange : MonoBehaviour
{
    // Start is called before the first frame update
    public RoomObject newRoom;

    Player player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            
            if (player.getRoom() != newRoom)
            {
                ///retire la toruch de la piece précédeante
                if (player.getRoom().lightSources.Contains(player.torch))
                {
                    player.getRoom().lightSources.Remove(player.torch);
                }

                //ajouter la torche dans la nouvelle piece
                player.setRoom(newRoom);
                if(!newRoom.lightSources.Contains(player.torch))
                {
                    newRoom.lightSources.Add(player.torch);  
                }
            }
        }
    }
}
