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


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputs = new PlayerInputs();
        moveInput = playerInputs.Movement.Axis;
        moveInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
    }

    private void FixedUpdate()
    {
        Vector3 direction = moveInput.ReadValue<Vector2>().normalized;
        direction.z = direction.y;
        direction.y = 0f;
        //transform.position += direction * speed * Time.deltaTime;
        //rb.AddForce(transform.position += direction * speed * Time.deltaTime);
        //transform.RotateAround(transform.position, transform.up, Mathf.Asin(direction.x - transform.forward.x));
        transform.LookAt(Vector3.Lerp(transform.forward, transform.position + direction * speed, 1f));
        rb.velocity = direction * speed;
    }
}
