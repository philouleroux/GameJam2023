using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Utilities;

public class Brazier : LightSource
{
    private Player player;
    private void Start()
    {
        player = GameManager.instance.Player;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            if (!player.HasTorch)
            {
                player.GetComponent<Grab>().Subscribe();
            }
            else
            {
                if (!IsLit)
                {
                    EventManager<string>.SubscribeParam(GameEventType.ANIM_OVER, Activate);
                    InputHandler.Subscribe(KeyAction.INTERACT, Activate);
                }
            }
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            if (!player.HasTorch)
            {
                player.GetComponent<Grab>().Unsubscribe();
            }
            else
            {
                EventManager<string>.UnsubscribeParam(GameEventType.ANIM_OVER, Activate);
                InputHandler.Unsubscribe(KeyAction.INTERACT);
            }
        }
    }
}
