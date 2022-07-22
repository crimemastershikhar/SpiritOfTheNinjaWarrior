using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    private Animator anim;
    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementRight;

    private string AXIS_X = "Horizontal";
    private string AXIS_Y = "Vertical";

    [SerializeField] private PlayerMovementMotor motor;
    [SerializeField] private Transform playerTransform;

    //Animation States
    private string ANIMATION_RUN = "Run";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        motor.movementDirection = Vector2.zero;
    }

    private void Start()
    {
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;
        
    }

    private void Update()
    {
        motor.movementDirection = Input.GetAxis(AXIS_X) * screenMovementRight + Input.GetAxis(AXIS_Y)
            * screenMovementForward;

        if (Input.GetAxis(AXIS_X) != 0 || Input.GetAxis(AXIS_Y) != 0)
        {
            anim.SetBool(ANIMATION_RUN, true);
        }
        else
        {
            anim.SetBool(ANIMATION_RUN, false);
        }
        
        //Diagnol run to be normalized
        if (motor.movementDirection.sqrMagnitude > 1)
            motor.movementDirection.Normalize();
    }

}