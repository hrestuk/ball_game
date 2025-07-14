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


    [SerializeField] private BallController ballController;

    [Header("BallSettings")]
    [SerializeField] private float ballForce = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float ballMass = 1f;

    private bool isGrounded = true;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float sphereRadius = 0.5f;

    [Header("Magnetic")]
    [SerializeField] private LayerMask magneticLayer;
    [SerializeField] private float magneticRange = 1.5f;

    private bool isStuck = false;
    private Vector3 surfaceNormal = Vector3.up;

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
        controller.Player.SwitchMode.performed += OnSwithModePerformed;
    }

    private void OnDisable()
    {
        controller.Player.Jump.performed -= OnJumpPerformed;
        controller.Player.SwitchMode.performed -= OnSwithModePerformed;
        controller.Disable();
    }


    private void FixedUpdate()
    {
        Debug.DrawRay(rb.worldCenterOfMass, -transform.up, Color.green);

        Vector3 moveDirection = GetMoveDirection();

        IsGrounded();
        MoveBall(moveDirection);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, magneticRange);
    }

    private Vector3 CalculateDirection()
    {   
        if (!isGrounded)
        {
            return Vector3.zero;
        }
        Vector2 moveInput = move.ReadValue<Vector2>();
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);

        Vector3 moveDir = new(moveInput.x, 0, moveInput.y);


        return moveDir;
    }
    private Vector3 CalculateMagneticDirection()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);

        Vector3 forward = Vector3.ProjectOnPlane(Vector3.up, surfaceNormal).normalized;

        // Вектор вправо по поверхности
        Vector3 right = Vector3.Cross(surfaceNormal, forward).normalized;

        // 3. Движение в проецированных координатах камеры
        Vector3 moveDir = forward * moveInput.y + right * moveInput.x;

        if (moveDir.sqrMagnitude > 1f)
        {
            moveDir.Normalize();
        }

    //---------
        Vector3 target = moveDir * speed;
        rb.velocity = Vector3.Lerp(rb.velocity, target, ballForce * Time.fixedDeltaTime);

        // Debug
        Debug.DrawRay(rb.position, surfaceNormal * 2f, Color.yellow);       // нормаль
        Debug.DrawRay(rb.position, forward * 2f, Color.green);     // камера "вперёд"
        Debug.DrawRay(rb.position, right * 2f, Color.blue);        // камера "вправо"
        Debug.DrawRay(rb.position, moveDir.normalized * 2f, Color.red);     // итог


        //return moveDir;
        return Vector3.zero;
    }

    private Vector3 GetMoveDirection()
    {
        Vector3 moveDirection;

        SetBallSettings();
        if (ballController.CurrentType == BallType.Magnetic)
        {
            TryMagnetStick();
            //moveDirection = isStuck ? CalculateMagneticDirection() : CalculateDirection();
            if (isStuck)
            {
                moveDirection = CalculateMagneticDirection();
            }
            else
            {
                moveDirection = Vector3.zero;
            }
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
        targetVelocity.y = rb.velocity.y;
        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, ballForce * Time.fixedDeltaTime);

        if (rb.velocity.sqrMagnitude < 0.01f)
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void Rotation(Vector3 direction)
    {
        ///
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

            // Поворот шара к поверхности
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, closestNormal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20f * Time.fixedDeltaTime);

            // Позиционируем шар чуть выше поверхности
            rb.MovePosition(contactPoint + closestNormal * sphereRadius * transform.localScale.x);

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
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void SetBallSettings()
    {
        ballForce = ballController.CurrentSettings.ballForce;
        jumpForce = ballController.CurrentSettings.jumpForce;
        speed = ballController.CurrentSettings.speed;
        ballMass = ballController.CurrentSettings.ballMass;
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

    private void OnSwithModePerformed(InputAction.CallbackContext context)
    {
        ballController.SwitchMode();
    }
}
