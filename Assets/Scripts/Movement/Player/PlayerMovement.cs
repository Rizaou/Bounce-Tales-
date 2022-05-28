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


    [SerializeField] bool isJumping = false;
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

        if (isJumping) { return; }
        if (context.performed)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            isJumping = true;
        }
    }



    private void HandleMovement()
    {
        if (isJumping) { return; }

        if (Mathf.Abs(rb.velocity.z) > _movementSpeed) { return; }
        float forwardValue = playerAction.Player.Movement.ReadValue<float>();

        rb.AddForce(Vector3.forward * forwardValue * _movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

    }

    private void OnCollisionEnter(Collision other)
    {
        /*
            * Herhangi bir objeye temas ediyorsa isJumping değişkenini false yap.

            * Eğer zaten false ise bir daha false değerini atma.
        */

        if (!isJumping) { return; }
        isJumping = false;
    }
}
