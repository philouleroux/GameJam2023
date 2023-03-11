using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputHandler.Subscribe(KeyAction.MOVE, walk);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void walk(InputAction.CallbackContext c)
    {
        Debug.Log("Vec2: " + c.ReadValue<Vector2>().ToString());
    }
}
