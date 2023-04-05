using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;
using Utilities;
using UnityEngine.InputSystem;

public class CameraAnimation : MonoBehaviour
{
    private CinemachineBrain cam;
    private Player player;
    private Action<InputAction.CallbackContext> tempInteract;
    private Action<InputAction.CallbackContext> tempMove;
    private Action<InputAction.CallbackContext> tempAttract;

    void Start()
    {
        cam = GetComponent<CinemachineBrain>();
        EventManager.Subscribe(GameEventType.PRAYING, StartAnim);
        player = GameManager.instance.Player;
    }

    private void StartAnim()
    {
        tempMove = InputHandler.Unsubscribe(KeyAction.AXIS);
        tempAttract = InputHandler.Unsubscribe(KeyAction.LEFT_CLICK);

        InputHandler.Subscribe(KeyAction.AXIS, CancelCamAnim);
        InputHandler.Subscribe(KeyAction.LEFT_CLICK, CancelCamAnim);
    }

    private void CancelCamAnim(InputAction.CallbackContext c)
    {
        player.IsPraying = false;
        cam.enabled = true;

        InputHandler.Subscribe(KeyAction.AXIS, tempMove);
        InputHandler.Subscribe(KeyAction.LEFT_CLICK, tempAttract);
    }

    private void Update()
    {
        if (player.IsPraying)
        {
            if (cam.enabled)
            {
                cam.enabled = false;
            }

            Vector3 dir = (player.transform.position - transform.position).normalized;

            if ((player.transform.position - transform.position).sqrMagnitude >= 64f)
            {
                transform.position += dir * 5f * Time.deltaTime;
                transform.Rotate(Vector3.right, -10f * Time.deltaTime);
            }
        }
        else
        {
            if (!cam.enabled)
            {
                cam.enabled = true;
            }
        }
    }
}
