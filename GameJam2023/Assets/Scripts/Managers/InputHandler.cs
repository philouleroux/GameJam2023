using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public enum KeyAction
{
    AXIS,
    INTERACT,
    LEFT_CLICK,

    COUNT
}

public static class InputHandler
{
    class InputActionPair
    {
        public InputAction action;
        public Action<InputAction.CallbackContext> callback;

        public InputActionPair(InputAction action, Action<InputAction.CallbackContext> callback)
        { 
            this.action = action;
            this.callback = callback;
        }
    }

    private static IDictionary<KeyAction, InputActionPair> callbacks;
    private static PlayerInputs playerInputs;

    static InputHandler()
    {
        playerInputs = new PlayerInputs();
        callbacks = new Dictionary<KeyAction, InputActionPair>((int)KeyAction.COUNT);
        playerInputs.Enable();
        BuildDictionary();
    }

    private static void BuildDictionary()
    {
        callbacks.Add(KeyAction.AXIS,
            new InputActionPair(playerInputs.Movement.Axis, null));
        callbacks.Add(KeyAction.INTERACT,
            new InputActionPair(playerInputs.Interactions.Interact, null));
        callbacks.Add(KeyAction.LEFT_CLICK,
            new InputActionPair(playerInputs.Spells.Block, null));
    }

    public static void Subscribe(KeyAction key, Action<InputAction.CallbackContext> callbackMethod)
    {
        if (callbacks[key].callback != null)
        {
            Unsubscribe(key);
        }

        callbacks[key].callback = callbackMethod;
        callbacks[key].action.started += callbackMethod;
    }

    public static void SubscribeToStart(KeyAction key, Action<InputAction.CallbackContext> callbackMethod)
    {
        if (callbacks[key].callback != null)
        {
            Unsubscribe(key);
        }

        callbacks[key].callback = callbackMethod;
        callbacks[key].action.started += callbackMethod;
    }

    public static void SubscribeToCancel(KeyAction key, Action<InputAction.CallbackContext> callbackMethod)
    {
        if (callbacks[key].callback != null)
        {
            Unsubscribe(key);
        }

        callbacks[key].callback = callbackMethod;
        callbacks[key].action.canceled += callbackMethod;

    }

    public static Action<InputAction.CallbackContext> Unsubscribe(KeyAction key)
    {
        Action<InputAction.CallbackContext> callback = null;
        if (IsPaired(key))
        {
            callback = callbacks[key].callback;
            callbacks[key].action.started -= callbacks[key].callback;
            callbacks[key].callback = null;
        }

        return callback;
    }
    
    public static Action<InputAction.CallbackContext> UnsubscribeStarted(KeyAction key)
    {
        Action<InputAction.CallbackContext> callback = null;
        if (IsPaired(key))
        {
            callback = callbacks[key].callback;
            callbacks[key].action.started -= callbacks[key].callback;
            callbacks[key].callback = null;
        }

        return callback;
    }
    
    public static Action<InputAction.CallbackContext> UnsubscribeCanceled(KeyAction key)
    {
        Action<InputAction.CallbackContext> callback = null;
        if (IsPaired(key))
        {
            callback = callbacks[key].callback;
            callbacks[key].action.canceled -= callbacks[key].callback;
            callbacks[key].callback = null;
        }

        return callback;
    }

    public static bool IsPaired(KeyAction key, Action<InputAction.CallbackContext> callback = null)
    {
        if (callback != null)
        {
            return callbacks[key].callback == callback;
        }
        return callbacks[key].callback != null;
    }

    public static bool CheckIfPressed(KeyAction key)
    {
        return (callbacks[key].action.IsPressed());
    }

    public static void AllowInteract(KeyAction key, bool interactable)
    {
        if (interactable)
        {
            callbacks[key].action.performed += callbacks[key].callback;
        }
        else
        {
            callbacks[key].action.performed -= callbacks[key].callback;
        }
    }
}