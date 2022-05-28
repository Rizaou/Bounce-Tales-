using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] float _movementSpeed = 2f;
    [SerializeField] float _jumpForce = 2f;
    [SerializeField] float maxSpeed = 10f;

    public Action whenInWater;
    public Action whenInLand;


    bool isJumping = false;
    bool inWater = false;
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
            if (inWater)
            {
                WaterJump();
            }
            else
            {
                LandJump();
            }

        }
    }

    private void LandJump()
    {
        rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        isJumping = true;
    }

    private void WaterJump()
    {

    }

    private void HandleMovement()
    {
        if (isJumping) { return; }

        if (inWater)
        {
            WaterMovement();
        }
        else
        {
            LandMovement();
        }


    }

    private void LandMovement()
    {

        if (Mathf.Abs(rb.velocity.z) > _movementSpeed) { return; }
        float forwardValue = playerAction.Player.Movement.ReadValue<float>();

        rb.AddForce(Vector3.forward * forwardValue * _movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

    }

    private void WaterMovement()
    {

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            inWater = true;
            whenInWater();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!inWater) { return; }

        if (other.gameObject.tag == "Water")
        {
            inWater = false;
            whenInLand();
        }
    }
}
