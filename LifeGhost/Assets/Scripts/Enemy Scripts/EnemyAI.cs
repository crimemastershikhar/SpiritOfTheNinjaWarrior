using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        //player = GameObject.Find("Ninja").transform;
        zombieTransform = this.transform;
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(zombieTransform.position, player.position);
        if (enemyHealth.realHealth > 0)
        {
            if (distance > 2.5f)
                Chase();
        }
        else
        {
            Attack();
        }
        
        transform.LookAt(player);
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
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}//Class
