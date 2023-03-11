using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : LightSource
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void Awake()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

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
