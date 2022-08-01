using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour {

    private Transform playerTransform;

    private Animator anim;

    private AudioSource audioSource;
    [SerializeField] private AudioClip footstep1;
    [SerializeField] private AudioClip footstep2;

    private string ANIMATION_RUN = "Run";

    private void Awake() {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerTransform = this.transform;

    }

    private void OnEnable() {
        EasyJoystick.On_JoystickMove += JoyStickMove;
        EasyJoystick.On_JoystickMoveEnd += JoyStickMoveEnd;

    }

    private void OnDisable() {
        EasyJoystick.On_JoystickMove -= JoyStickMove;
        EasyJoystick.On_JoystickMoveEnd -= JoyStickMoveEnd;

    }

    void JoyStickMove(MovingJoystick move) {
        float angle = move.Axis2Angle(true);
        playerTransform.rotation = Quaternion.Euler(new Vector3(0, angle - 45, 0));
        anim.SetBool(ANIMATION_RUN, true);

    }

    void JoyStickMoveEnd(MovingJoystick move) {
        anim.SetBool(ANIMATION_RUN, false);

    }

    void FootStepOne(bool play) {
        if (play) {
            audioSource.PlayOneShot(footstep1);
        }
    }

    void FootStepTwo(bool play) {
        if (play) {
            audioSource.PlayOneShot(footstep2);
        }
    }


































}//Class
