using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallSettings")]
public class BallSettings : ScriptableObject
{
    public float ballForce;
    public float ballMass;
    public float maxSpeed;
    public float jumpForce;
}
