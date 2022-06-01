using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] float _landSpeed = 5f;
    [SerializeField] float _waterSpeed = 1f;
    [SerializeField] float _landJumpForce = 10f;
    [SerializeField] float _waterJumpForce = 5f;
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
        rb.AddForce(Vector3.up * _landJumpForce, ForceMode.VelocityChange);
        isJumping = true;
    }

    private void WaterJump()
    {
        rb.AddForce(Vector3.up * _waterJumpForce, ForceMode.VelocityChange);
        isJumping = false;
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

        if (Mathf.Abs(rb.velocity.z) > _landSpeed) { return; }
        float forwardValue = playerAction.Player.Movement.ReadValue<float>();

        rb.AddForce(Vector3.forward * forwardValue * _landSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

    }

    private void WaterMovement()
    {
        if (Mathf.Abs(rb.velocity.magnitude) > _waterSpeed) { return; }
        float forwardValue = playerAction.Player.Movement.ReadValue<float>();

        rb.AddForce(Vector3.forward * forwardValue * _waterSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);

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
