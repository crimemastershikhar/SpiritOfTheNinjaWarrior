using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMotor : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movementDirection;

    private Rigidbody myBody;
    public float walkingSpeed;
    public float walkingSnapyness;
    public float turningSmoothing;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = movementDirection * walkingSpeed;
        Vector3 deltaVelocity = targetVelocity - myBody.velocity;
        if (myBody.useGravity)
        {
            deltaVelocity.y = 0;                                   //Char cant move upwards
        }

        myBody.AddForce(deltaVelocity * walkingSnapyness, ForceMode.Acceleration);
        Vector3 faceDir = movementDirection;
        if(faceDir == Vector3.zero)
        {
            myBody.angularVelocity = Vector3.zero;
        }
        else
        {
            float rotationAngle = AngleAroundAxis(transform.forward, faceDir, Vector3.up);
            myBody.angularVelocity = (Vector3.up * rotationAngle * turningSmoothing);
        }        
    }

    //To change the angle of our character
    private float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
    {
        dirA = dirA - Vector3.Project(dirA, axis);
        dirB = dirB - Vector3.Project(dirB, axis);
        float angle = Vector3.Angle(dirA, dirB);
        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1: 1);
    }
}
