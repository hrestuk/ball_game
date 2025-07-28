using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMover : MonoBehaviour
{
    [Tooltip("To choose direction (x, y, z), set a vector like: (1, 0, 0); ")]
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Transform objectToMove;
    [SerializeField] private float speed;
    [SerializeField] private float area;

    private bool isTriggered = false;
    private Vector3 targetPos;

    private void MoveObject()
    {   
        objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPos, Time.deltaTime * speed);
    }

    private void Update()
    {
        if (isTriggered && objectToMove.position != targetPos)
        {
            MoveObject();
        }
    }

    private void ApplyDirection()
    {
        targetPos = (moveDirection * area) + objectToMove.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Player"))
        {
            ApplyDirection();
            isTriggered = true;
        }
    }
}
