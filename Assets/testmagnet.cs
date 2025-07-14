using System.Collections.Generic;
using UnityEngine;

public class testmagnet : MonoBehaviour
{
    public float magnetForce = 100;

    List<Rigidbody> caughtRigidbodies = new List<Rigidbody>();
    [SerializeField] private BallController ballController;

    void FixedUpdate()
    {
        for (int i = 0; i < caughtRigidbodies.Count; i++)
        {
            Rigidbody rb = caughtRigidbodies[i];
            if (ballController.CurrentType != BallType.Magnetic)
            {
                caughtRigidbodies.Remove(rb);
                break;
            }

            rb.velocity = (transform.position - (rb.transform.position + rb.centerOfMass)) * magnetForce / rb.mass * Time.deltaTime;

            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (!caughtRigidbodies.Contains(rb) && ballController.CurrentType == BallType.Magnetic)
            {
                //Add Rigidbody
                caughtRigidbodies.Add(rb);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (caughtRigidbodies.Contains(rb))
            {
                //Remove Rigidbody
                caughtRigidbodies.Remove(rb);
            }
        }
    }
    
}