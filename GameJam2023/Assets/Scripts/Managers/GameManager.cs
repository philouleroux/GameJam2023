using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player Player { get; set; }

    public int gamePoint { get; set; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        gamePoint = 0;
        EventManager.Subscribe(GameEventType.HOTEL_PRAYED, addPoint);
        EventManager.Subscribe(GameEventType.HOTEL_LOST, subPoint);
    }

    void Update()
    {
        
    }

    void addPoint()
    {
        gamePoint++;
        EventManager.Publish(GameEventType.UPDATED_UI_POINT);
    }

    void subPoint()
    {
        gamePoint--;
        EventManager.Publish(GameEventType.UPDATED_UI_POINT);
    }
}
