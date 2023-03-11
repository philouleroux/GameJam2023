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
        InputHandler.SubscribeToStart(KeyAction.INTERACT, StartGrab);
        InputHandler.SubscribeToCancel(KeyAction.INTERACT, StopGrab);
    }

    private void StartGrab(InputAction.CallbackContext obj)
    {
        Debug.Log("Grab");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, float.MaxValue, layerMaskGrabbable))
        {
            Debug.Log("hit");

            grabbableObject = hit.transform;
            grabbableObject.transform.SetParent(transform);
        }
    }

    private void StopGrab(InputAction.CallbackContext obj)
    {
        Debug.Log("NoGrab");
        grabbableObject.transform.SetParent(null);
        grabbableObject = null;
    }
}
