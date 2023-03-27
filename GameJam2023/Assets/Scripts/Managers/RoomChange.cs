using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;


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
            if (player.GetRoom() != newRoom)
            {
                ///retire la toruch de la piece précédeante
                if (player.GetRoom().lightSources.Contains(player.torch))
                {
                    player.GetRoom().lightSources.Remove(player.torch);
                }

                //ajouter la torche dans la nouvelle piece
                player.SetRoom(newRoom);
                if(!newRoom.lightSources.Contains(player.torch))
                {
                    newRoom.lightSources.Add(player.torch);
                    EventManager.Publish(GameEventType.LIGHT_LIT);
                }
            }
        }
        else if (other.CompareTag("Brazier"))
        {
            Brazier brazier = other.GetComponent<Brazier>();
            //Brazier temp = (Brazier)other;
            Debug.Log("Brazier triggered");
            if (player.GetRoom() != newRoom)
            {
                ///retire le brazier de la piece précédeante
                if (player.GetRoom().lightSources.Contains(brazier))
                {
                    player.GetRoom().lightSources.Remove(brazier);
                }

                //ajouter le brazier dans la nouvelle piece
                player.SetRoom(newRoom);
                if (!newRoom.lightSources.Contains(brazier))
                {
                    newRoom.lightSources.Add(brazier);
                    EventManager.Publish(GameEventType.LIGHT_LIT);
                }
            }
        }
    }
}
