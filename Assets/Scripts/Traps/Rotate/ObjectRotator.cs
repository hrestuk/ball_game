using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [Tooltip("Choose type of rotation")]
    [SerializeField] RotationType currentType;

    [Tooltip("To choose axis (x, y, z), set a vector like: (1, 0, 0); ")]
    [SerializeField] private Vector3 axis;

    [Tooltip("Only for Swing type")]
    [SerializeField] private float angle = 45f;
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        ApplyRotation();
    }
    
    private void ApplyRotation()
    {
        switch (currentType)
        {
            case RotationType.Cyclic:
            {
                CyclicRotation();
                break;
            }
            case RotationType.Swing:
            {
                SwingRotation();
                break;
            }

        }
    }

    private void CyclicRotation()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }

    private void SwingRotation()
    {
        float currentAngle = angle * Mathf.Sin(Time.time * speed);
        transform.localRotation = Quaternion.Euler(axis*currentAngle);

    }
}
