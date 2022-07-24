using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//Class Summary:  Generate Prefab out of the arrows.||  Also using timercounter to control the spawn rate 
public class Skill_PrefabGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] skillPrefabs;

    [SerializeField] private int thisManyTime = 3;  //how many times to create variables
    [SerializeField] private float overThisTime = 3f; // over whch interval should we create
    
    [SerializeField] private float x_Width, y_Width, z_Width;   //position our GO 
    [SerializeField] private float x_RotMax, y_RotMax = 180f, z_RotMax;

    private bool allUseSameRotation = false;  //determine evry prefab that we create use same rota. as before
    private bool allRotationDecided = false;  // determine that every rot. for every GO is decided

    private float x_Cur, y_Cur, z_Cur;
    private float x_RotCur, y_RotCur, z_RotCur; 
    
    private int randNum;  //spawn random prefabs
    private float trigger;
    
    private float timeCounter;  //How many times we call this function
    private float effectCounter;

    private void Start()
    {
        if (thisManyTime < 1)
            thisManyTime = 1;
        
        trigger = overThisTime / thisManyTime;  //Define interval of time
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter > trigger && effectCounter <= thisManyTime)
            randNum = Random.Range(0, skillPrefabs.Length);

        x_Cur = transform.position.x + (Random.value * x_Width) - (x_Width * 0.5f);
        y_Cur = transform.position.y + (Random.value * y_Width) - (y_Width * 0.5f);
        z_Cur = transform.position.z + (Random.value * z_Width) - (z_Width * 0.5f);

        if (!allUseSameRotation || !allRotationDecided)
        {
            x_RotCur = transform.rotation.x + (Random.value * x_RotMax * 2) - (x_RotMax);
            y_RotCur = transform.rotation.y + (Random.value * y_RotMax * 2) - (y_RotMax);
            z_RotCur = transform.rotation.z + (Random.value * z_RotMax * 2) - (z_RotMax);
            allRotationDecided = true;

        }

        GameObject skill = Instantiate(skillPrefabs[randNum], new Vector3(x_Cur, y_Cur, z_Cur), 
            transform.rotation);
        skill.transform.Rotate(x_RotCur, y_RotCur, z_RotCur);

        timeCounter -= trigger;
        effectCounter += 1;

    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
