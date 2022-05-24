using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 2f;
    [SerializeField] float _jumpForce = 2f;
    [SerializeField] float maxSpeed = 10f;

    PlayerInputAction playerAction;
    Rigidbody rb;


    private void Awake()
    {
        playerAction = new PlayerInputAction();
        playerAction.Player.Enable();
        playerAction.Player.Jump.performed += HandleJump;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandleMovement();

    }

    private void HandleJump(InputAction.CallbackContext context)
    {

        if (context.performed)
        {

            rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        }
    }

    private void HandleMovement()
    {
        if (Mathf.Abs(rb.velocity.z) > _movementSpeed) { return; }
        float forwardValue = playerAction.Player.Movement.ReadValue<float>();

        rb.AddForce(Vector3.forward * forwardValue * _movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

    }
}
