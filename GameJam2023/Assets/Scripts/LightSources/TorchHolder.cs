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

    private void OnEnable()
    {
        EventManager<string>.SubscribeParam(GameEventType.ANIM_OVER, SetTorchHolderState);
    }

    private void OnDisable()
    {
        
    }

    private void SetTorchHolderState(string animType)
    {
        if (animType.Equals("DropTorch"))
        {
            GameManager.instance.Player.torch.gameObject.SetActive(false);
            holdingTorch.gameObject.SetActive(true);
            noTorch.gameObject.SetActive(false);
            GameManager.instance.Player.HasTorch = false;
        }
    }

    void Activate(InputAction.CallbackContext c)
    {
        isHolding = !isHolding;

        if (isHolding && GameManager.instance.Player.HasTorch)
        {
            GameManager.instance.Player.Animator.SetTrigger("DropTorch");
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
        }
    }
}
