using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add namespace

public class Skill_RotateObject : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;

    private void Update()
    {
        transform.Rotate(new Vector3(x,y,z) * Time.deltaTime);
    }
}
