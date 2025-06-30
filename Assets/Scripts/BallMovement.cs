using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    private Controller controller;
    private InputAction move;
    private Vector3 inputDirection;
    private Rigidbody rb;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float sphereRadius = 0.5f;

    [Header("Movement")]
    [SerializeField] private float ballForce = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float maxSpeed = 10f;

    private bool isGrounded = true;

    private void Awake()
    {
        controller = new Controller();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        controller.Enable();
        move = controller.Player.Move;
        controller.Player.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        controller.Player.Jump.performed -= OnJumpPerformed;
        controller.Disable();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();
        inputDirection = new(moveInput.x, 0f, moveInput.y);

        if (inputDirection.sqrMagnitude > 1f)
        {
            inputDirection.Normalize();
        }

        IsGrounded();

        if (isGrounded)
            rb.drag = inputDirection.sqrMagnitude < 0.01f ? 5 : 1.5f;
        else
            rb.drag = 0;

        rb.AddForce(inputDirection * ballForce, ForceMode.Force);

        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }

    }

    private void IsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (0.1f + sphereRadius) * transform.localScale.x, groundLayer);
        Debug.Log(isGrounded);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Jump();
    }
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
