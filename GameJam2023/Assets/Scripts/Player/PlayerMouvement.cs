using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] float speed = 10f;

    private InputAction moveInput;
    private PlayerInputs playerInputs;
    private Player player;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputs = new PlayerInputs();
        moveInput = playerInputs.Movement.Axis;
        moveInput.Enable();
        player = GetComponent<Player>();
    }

    private void OnDisable()
    {
        moveInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 direction = moveInput.ReadValue<Vector2>().normalized;
        if (direction != Vector3.zero)
        {
            if (player.IsGrabbing && !player.Animator.GetCurrentAnimatorStateInfo(0).IsName("GrabPull"))
            {
                player.Animator.SetBool("GrabPull", true);
            }
            else if (player.HasTorch && !player.Animator.GetBool("Walk"))
            {
                Debug.Log("Here");
                player.Animator.SetBool("Walk", true);
            }
            else if (!player.IsGrabbing && !player.HasTorch && !player.Animator.GetCurrentAnimatorStateInfo(0).IsName("WalkNoTorch"))
            {
                player.Animator.SetBool("WalkNoTorch", true);
            }
        }
        else
        {
            player.Animator.SetBool("GrabPull", false);
            player.Animator.SetBool("Walk", false);
            player.Animator.SetBool("WalkNoTorch", false);

            if (player.IsGrabbing && !player.Animator.GetCurrentAnimatorStateInfo(0).IsName("GrabIdle"))
            {
                player.Animator.SetBool("GrabIdle", true);
            }
            else if ((!player.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") &&
                      !(player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0f) &&
                      !player.Animator.IsInTransition(0)))
            {
                player.Animator.SetTrigger("Idle");
            }
        }

        direction.z = direction.y;
        direction.y = 0f;

        transform.LookAt(transform.position + direction * speed);
        rb.velocity = direction * speed;
    }
}
