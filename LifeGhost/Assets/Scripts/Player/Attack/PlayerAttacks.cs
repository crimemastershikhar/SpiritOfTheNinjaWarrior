using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator anim;
    
    //Animation States
    private string ANIMATION_ATTACK = "Attack";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleButtonPresses();
    }

    private void HandleButtonPresses()
    {
        if (Input.GetKeyDown(KeyCode.E))
            anim.SetBool(ANIMATION_ATTACK, true);

        if (Input.GetKeyUp(KeyCode.E))
            anim.SetBool(ANIMATION_ATTACK, false);


    }
}