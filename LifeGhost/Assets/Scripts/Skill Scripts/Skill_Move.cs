using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class summary: Moving the fireball

public class Skill_Move : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    [SerializeField] private bool local = false;

    private void Update()
    {
        if (local)
            transform.Translate(new Vector3(x, y, z) * Time.deltaTime);
        
        if(!local)
            transform.Translate(new Vector3(x,y,z) * Time.deltaTime, Space.World);
    }
}
