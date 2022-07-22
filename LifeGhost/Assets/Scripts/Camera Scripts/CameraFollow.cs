using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform myTransform;  

    [SerializeField] private Vector3 offset = new Vector3();
    [SerializeField] private Transform target;

    //Use below in case of multiple scenes
    
    /*private void Awake()
    {
        target = GameObject.Find("Ninja").transform;
    }*/

    private void Start()
    {
        myTransform = this.transform;
    }

    private void Update()
    {
        if (target)
        {
            myTransform.position = target.position + offset;
            myTransform.LookAt(target.position, Vector3.up); 
        }
    }
}