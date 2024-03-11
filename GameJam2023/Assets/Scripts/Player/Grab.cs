using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    private Transform grabbableObject;
    [SerializeField] LayerMask layerMaskGrabbable;
    [SerializeField] float rangeGrab;

    void Start()
    {

    }

    public void Subscribe()
    {
        InputHandler.SubscribeToStart(KeyAction.INTERACT, StartGrab);
        InputHandler.SubscribeToCancel(KeyAction.INTERACT, StopGrab);
    }

    public void Unsubscribe()
    {
        InputHandler.UnsubscribeStarted(KeyAction.INTERACT);
        InputHandler.UnsubscribeCanceled(KeyAction.INTERACT);
    }

    private void StartGrab(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, layerMaskGrabbable))
        {
            Debug.Log("hit");

            grabbableObject = hit.transform;
            Brazier source = grabbableObject.GetComponentInChildren<Brazier>();
            if (!source.IsLit)
            {
                GetComponent<Player>().IsGrabbing = true;
                grabbableObject.transform.SetParent(transform);
            }
            else
            {
                // repousse le joueur?
                GetComponent<Player>().Animator.SetTrigger("Burn");
            }
        }
    }

    private void StopGrab(InputAction.CallbackContext obj)
    {
        if (grabbableObject != null)
        {
            GetComponent<Player>().IsGrabbing = false;
            GetComponent<Player>().Animator.SetTrigger("Idle");
            grabbableObject.transform.SetParent(null);
            grabbableObject = null;
            Unsubscribe();
        }
    }
}
