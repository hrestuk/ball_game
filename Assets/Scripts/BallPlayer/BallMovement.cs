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
    private Rigidbody rb;
    private SphereCollider sphereCollider;

    [SerializeField] private Transform ballTransform;
    [SerializeField] private BallController ballController;

    [Header("BallSettings")]
    [SerializeField] private float ballForce = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float ballMass = 1f;
    [SerializeField] private float sphereRadius = 0.5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float ballScale = 1f;

    private bool isGrounded = true;
    [SerializeField] private LayerMask groundLayer;

    [Header("Magnetic")]
    [SerializeField] private LayerMask magneticLayer;
    [SerializeField] private float magneticRange = 1.5f;

    private bool isStuck = false;
    private Vector3 surfaceNormal = Vector3.up;

    private void Awake()
    {
        controller = new Controller();
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnEnable()
    {
        controller.Enable();
        move = controller.Player.Move;
        controller.Player.Jump.performed += OnJumpPerformed;
        controller.Player.SwitchToNormalMode.performed += OnSwitchNormalPerformed;
        controller.Player.SwitchToHeavyMode.performed += OnSwitchHeavyPerformed;
        controller.Player.SwitchToMagneticMode.performed += OnSwitchMagneticPerformed;
    }

    private void OnDisable()
    {
        controller.Player.Jump.performed -= OnJumpPerformed;
        controller.Player.SwitchToNormalMode.performed -= OnSwitchNormalPerformed;
        controller.Player.SwitchToHeavyMode.performed -= OnSwitchHeavyPerformed;
        controller.Player.SwitchToMagneticMode.performed -= OnSwitchMagneticPerformed;
        controller.Disable();
    }


    private void FixedUpdate()
    {
        Debug.DrawRay(rb.worldCenterOfMass, -transform.up, Color.green);

        Vector3 moveDirection = GetMoveDirection();

        IsGrounded();
        MoveBall(moveDirection);
        ChangeBallScale();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, magneticRange);
    }

    //Ball direction
    private Vector3 CalculateDirection()
    {
        
        Vector2 moveInput = move.ReadValue<Vector2>();
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);

        Vector3 moveDir = new(moveInput.x, 0, moveInput.y);

        if (!isGrounded)
            return moveDir/2.3f;

        return moveDir;
    }

    //Magnetic Ball direction
    private Vector3 CalculateMagneticDirection()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);

        Vector3 forward = Vector3.ProjectOnPlane(Vector3.up, surfaceNormal).normalized;

        Vector3 right = Vector3.Cross(surfaceNormal, forward).normalized;

        Vector3 moveDir = forward * moveInput.y + right * moveInput.x;

        if (moveDir.sqrMagnitude > 1f)
        {
            moveDir.Normalize();
        }

        // Debug
        Debug.DrawRay(rb.position, surfaceNormal * 2f, Color.yellow);
        Debug.DrawRay(rb.position, forward * 2f, Color.green);
        Debug.DrawRay(rb.position, right * 2f, Color.blue);
        Debug.DrawRay(rb.position, moveDir.normalized * 2f, Color.red);

        return moveDir;
    }

    private Vector3 GetMoveDirection()
    {
        Vector3 moveDirection;
        surfaceNormal = Vector3.up;

        if (ballController.CurrentType == BallType.Magnetic)
        {
            TryMagnetStick();

            ballController.SetCurrentSettings(isStuck ? BallType.Magnetic : BallType.MagneticGrounded);

            SetBallSettings();
            moveDirection = isStuck ? CalculateMagneticDirection() : CalculateDirection();

        }
        else
        {
            moveDirection = CalculateDirection();
        }

        return moveDirection;
    }

    private void MoveBall(Vector3 moveDirection)
    {
        Vector3 targetVelocity = moveDirection * speed;

        if (ballController.CurrentType != BallType.Magnetic)
            targetVelocity.y = rb.velocity.y;

        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, ballForce * Time.fixedDeltaTime);

        if (rb.velocity.sqrMagnitude < 0.01f)
        {
            rb.velocity = Vector3.zero;
        }

        Rotation(rb.velocity);
    }

    private void ChangeBallScale()
    {
        float newScale = Mathf.MoveTowards(ballTransform.localScale.x, ballScale, Time.fixedDeltaTime * 3f);
        ballTransform.localScale = new(newScale, newScale, newScale);
    }

    private void Rotation(Vector3 direction)
    {
        if (direction.sqrMagnitude < 0.01f)
            return;

        if (surfaceNormal == Vector3.up)
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,0);

        Quaternion targetRotation = Quaternion.LookRotation(direction, surfaceNormal);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

        float distance = rb.velocity.magnitude * Time.fixedDeltaTime;
        float angle = ((distance / sphereRadius) ) * Mathf.Rad2Deg;

        ballTransform.Rotate(Vector3.right, angle, Space.Self);

    }

    private void TryMagnetStick()
    {
        Collider[] hits = Physics.OverlapSphere(rb.worldCenterOfMass, magneticRange, magneticLayer);
        float closestDistance = Mathf.Infinity;
        Vector3 closestNormal = Vector3.up;
        Vector3 contactPoint = Vector3.zero;
        bool found = false;

        foreach (var col in hits)
        {
            Vector3 closest = col.ClosestPoint(rb.worldCenterOfMass);
            Vector3 dir = rb.worldCenterOfMass - closest;
            float distance = dir.magnitude;

            if (distance < closestDistance)
            {
                RaycastHit hit;
                if (Physics.Raycast(rb.worldCenterOfMass, -dir.normalized, out hit, magneticRange + 0.1f, magneticLayer))
                {
                    closestDistance = distance;
                    closestNormal = hit.normal;
                    contactPoint = hit.point;
                    found = true;
                }
            }
        }

        if (found)
        {
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, closestNormal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20f * Time.fixedDeltaTime);

            rb.MovePosition(contactPoint + closestNormal * sphereRadius * ballTransform.localScale.x);

            surfaceNormal = closestNormal;
            isStuck = true;
        }
        else
        {
            rb.useGravity = true;
            isStuck = false;
        }
    }


    public void Jump()
    {
        if (isGrounded)
            rb.AddForce((Vector3.up) * jumpForce, ForceMode.Impulse);
    }

    private void SetBallSettings()
    {   
        ballForce = ballController.CurrentSettings.ballForce;
        jumpForce = ballController.CurrentSettings.jumpForce;
        speed = ballController.CurrentSettings.speed;
        ballMass = ballController.CurrentSettings.ballMass;
        sphereRadius = ballController.CurrentSettings.colliderRadius;
        ballScale = ballController.CurrentSettings.scale;

        ApplySettings();
    }

    private void ApplySettings()
    {
        sphereCollider.radius = sphereRadius;
        rb.mass = ballMass;
    }

    private void IsGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, (0.1f + sphereRadius), groundLayer);
        Debug.Log(isGrounded);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void OnSwitchNormalPerformed(InputAction.CallbackContext context)
    {
        ballController.SwitchToNormal();
        SetBallSettings();
    }
    private void OnSwitchHeavyPerformed(InputAction.CallbackContext context)
    {
        ballController.SwitchToHeavy();
        SetBallSettings();
    }
    private void OnSwitchMagneticPerformed(InputAction.CallbackContext context)
    {
        ballController.SwitchToMagnetic();
        SetBallSettings();
    }
}
