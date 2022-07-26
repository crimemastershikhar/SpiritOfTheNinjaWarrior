using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;

    //Animation States
    private string ANIMATION_ATTACK = "Attack";
    private string ANIMATION_RUN = "Run";
    private string ANIMATION_SPEED = "Speed";
    private string ANIMATION_VICTORY = "Victory";
    private string BASE_LAYER_STAND = "Base Layer.Stand";    //layer containing all animations + checking Stand State

    [SerializeField] private Transform player;
    [SerializeField] private float chaseSpeed;

    private Animator anim;
    private CapsuleCollider col;
    private Transform zombieTransform;

    private NavMeshAgent navAgent;
    [SerializeField] private Transform[] navPoints;
    private int naviagationIndex;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        //player = GameObject.Find("Ninja").transform;
        zombieTransform = this.transform;
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        
        navAgent = GetComponent<NavMeshAgent>();
        naviagationIndex = Random.Range(0, navPoints.Length);  //determine where zombie is going to go first 
        navAgent.SetDestination(navPoints[naviagationIndex].position);  //pos where GO needs to go 

    }

    private void Update()
    {
        float distance = Vector3.Distance(zombieTransform.position, player.position);

        if (enemyHealth.realHealth > 0)
        {
            if (distance > 7f)
            {
                Search();
                navAgent.isStopped = false;
            }
            else
            {
                navAgent.isStopped = true;

                if (distance > 2.5f)
                {
                    Chase();
                }
                else
                {
                    Attack();
                }
                
                transform.LookAt(player);

            }
            
        }
        
    }

    void Chase()
    {
        anim.SetBool(ANIMATION_RUN, true);
        anim.SetFloat(ANIMATION_SPEED, chaseSpeed);
        anim.SetBool(ANIMATION_ATTACK, false);
        
    }

    void Attack()
    {
        anim.SetBool(ANIMATION_ATTACK, true);
        
    }

    void Search()
    {
        if (navAgent.remainingDistance <= 0.5f)
        {
            anim.SetFloat(ANIMATION_SPEED,0f);
            anim.SetBool(ANIMATION_ATTACK,false);
            anim.SetBool(ANIMATION_RUN,false);

            if (naviagationIndex == navPoints.Length - 1)
            {
                naviagationIndex = 0;
            }
            else
            {
                naviagationIndex++;
            }

            navAgent.SetDestination(navPoints[naviagationIndex].position);
        }
        else
        {
            anim.SetFloat(ANIMATION_SPEED,1f);
            anim.SetBool(ANIMATION_ATTACK,false);
            anim.SetBool(ANIMATION_RUN,false);
        }
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}//Class
