using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class summary: 

public class Skill_RandomScale : MonoBehaviour
{
    private float minScale = 1f, maxScale = 2f;

    private void Start()
    {
        float random = Random.Range (minScale, maxScale);
        transform.localScale = new Vector3(random, random, random);
    }
}
