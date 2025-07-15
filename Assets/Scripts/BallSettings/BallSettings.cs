using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BallSettings")]
public class BallSettings : ScriptableObject
{
    public float ballForce;
    public float ballMass;
    public float speed;
    public float jumpForce;
    public float radius;
}
