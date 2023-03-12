using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

public class TorchHolder : MonoBehaviour
{
    HoldingTorch holdingTorch;
    NoTorch noTorch;

    protected System.Action<InputAction.CallbackContext> lastCallback;

    bool isHolding = false;
    void Awake()
    {
        //base.Awake();
        holdingTorch = this.GetComponentInChildren<HoldingTorch>();
        noTorch = this.GetComponentInChildren<NoTorch>();

        if (holdingTorch == null )
        {
            Debug.Log("!!!!! holdingTorch is null");
        }
    }


    void Activate(InputAction.CallbackContext c)
    {
        isHolding = !isHolding;

        if (isHolding && GameManager.instance.Player.HasTorch)
        {
            GameManager.instance.Player.HasTorch = false;
            GameManager.instance.Player.torch.gameObject.SetActive(false);
            holdingTorch.gameObject.SetActive(true);
            noTorch.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.Player.HasTorch = true;
            GameManager.instance.Player.torch.gameObject.SetActive(true);
            holdingTorch.gameObject.SetActive(false);
            noTorch.gameObject.SetActive(true);
        }

        InputHandler.Unsubscribe(KeyAction.INTERACT);
    }

    void OnTriggerEnter(Collider other)
    {
        //base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player enterd");
            lastCallback = InputHandler.Unsubscribe(KeyAction.INTERACT);
            InputHandler.Subscribe(KeyAction.INTERACT, Activate);
        }
    }

     void OnTriggerExit(Collider other)
    {
        //base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            InputHandler.Unsubscribe(KeyAction.INTERACT);
            if (lastCallback != null)
            {
                InputHandler.Subscribe(KeyAction.INTERACT, lastCallback);
            }
        }
    }
}
