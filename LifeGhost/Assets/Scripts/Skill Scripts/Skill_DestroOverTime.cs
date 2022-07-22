using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DestroOverTime : MonoBehaviour
{
    [SerializeField]
    private float timer;

    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
