using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        transform.position = playerTransform.position + offset;
    }
    private void LateUpdate()
    {
        transform.position = playerTransform.position + offset;
    }
}
