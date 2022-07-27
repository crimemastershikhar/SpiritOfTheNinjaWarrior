using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    //[SerializeField] private float realHealth;
    public float realHealth { get; private set; }

    private AudioSource audioSource;
    [SerializeField] private AudioClip enemyDeadSound;

    [SerializeField] private GameObject attackPointOne;
    [SerializeField] private GameObject attackPointTwo;

    [SerializeField] private GameObject deadEffect;
    [SerializeField] private Transform deadEffectPoint;

    private Animator anim;
    private bool enemyDead;
    private bool enemyIsHit;

    private string ANIMATION_DEAD = "Dead";
    private string ANIMATION_BEATTACKED = "BeAttacked";
    private string BASE_LAYER_DYING = "Base Layer.Dying";
    private string BASE_LAYER_HIT = "Base Layer.Hit";
    private string ANIMATION_ATTACK = "Attack";


    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();


    }

    private void Start() {
        realHealth = 100f;

    }

    private void Update() {
        if (enemyDead) {
            StopDeadAnimation();
        }

        if (enemyIsHit) {
            EnemyAttacked();

        } else {
            StopEnemyHit();
        }

    }

    public void EnemyTakeDamage(float amount) {
        realHealth -= amount;
        if (realHealth <= 0) {
            realHealth = 0;
            EnemyDying();
        }

        if (amount > 0)
            enemyIsHit = true;

    }

    private void EnemyDying() {
        anim.SetBool(ANIMATION_DEAD, true);
        anim.SetBool(ANIMATION_BEATTACKED, false);
        enemyDead = true;
        StartCoroutine(DeadEffect());
        attackPointOne.SetActive(false);
        attackPointTwo.SetActive(false);
        audioSource.PlayOneShot(enemyDeadSound);
    }

    private void StopDeadAnimation() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_DYING))
            anim.SetBool(ANIMATION_DEAD, false);

    }

    void EnemyAttacked() {
        anim.SetBool(ANIMATION_BEATTACKED, true);
        anim.SetBool(ANIMATION_ATTACK, false);

        transform.Translate(Vector3.back * 0.5f);     //Pushing enemy back
        enemyIsHit = false;

    }

    void StopEnemyHit() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_HIT))
            anim.SetBool(ANIMATION_BEATTACKED, false);

    }

    IEnumerator DeadEffect() {
        yield return new WaitForSeconds(2f);
        Instantiate(deadEffect, deadEffectPoint.position, deadEffectPoint.rotation);
        Destroy(gameObject);

    }



































}//class
