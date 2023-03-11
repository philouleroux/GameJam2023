using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Brazier : LightSource
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            lastCallback = InputHandler.Unsubscribe(KeyAction.INTERACT);
            InputHandler.Subscribe(KeyAction.INTERACT, Activate);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            InputHandler.Unsubscribe(KeyAction.INTERACT);
            InputHandler.Subscribe(KeyAction.INTERACT, lastCallback);
        }
    }
}
