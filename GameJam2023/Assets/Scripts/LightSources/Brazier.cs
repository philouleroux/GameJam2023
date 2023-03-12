using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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
        if(!player.HasTorch)
        {
            player.GetComponent<Grab>().Subscribe();
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (!player.HasTorch)
        {
            player.GetComponent<Grab>().Unsubscribe();
        }
    }
}
