using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Tooltip("To choose direction (x, y, z), set a vector like: (1, 0, 0); ")]
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float area = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeOffset = 0f;

    private Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 offset = moveDirection * MathF.Sin(speed * Time.time + timeOffset) * area;
        transform.position = startPos + offset;
    }

  
}
