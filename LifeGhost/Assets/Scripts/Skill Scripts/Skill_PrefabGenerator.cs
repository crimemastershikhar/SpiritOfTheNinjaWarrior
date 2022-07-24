using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        trigger = overThisTime / thisManyTime;  //Define interval of time
    }
}
