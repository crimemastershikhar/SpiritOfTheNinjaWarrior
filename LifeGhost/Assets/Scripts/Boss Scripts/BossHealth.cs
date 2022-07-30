using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {
    public float realHealth { get; private set; }

    [SerializeField] private AudioClip deadSound;
    private AudioSource audioSource;

    private Animator anim;
    private bool isDead;

    private CapsuleCollider col;

    private string BASE_LAYER_DEAD = "BaseLayer.Dead";
    private string ANIMATION_DEAD = "Dead";

    private void Awake() {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        col = GetComponent<CapsuleCollider>();

    }

    private void Start() {
        realHealth = 200f;

    }

    private void Update() {
        if (isDead) {
            StopDeadAnimation();

        }

    }

    private void BossDying() {
        anim.SetBool(ANIMATION_DEAD, true);
        isDead = true;
        col.enabled = false;
        audioSource.PlayOneShot(deadSound);

    }

    public void BossTakeDamage(float amount) {
        realHealth -= amount;

        Debug.Log("Boss Taking Damage " + realHealth);

        if (realHealth <= 0) {
            realHealth = 0;
            BossDying();
        }

    }

    private void StopDeadAnimation() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_DEAD)) {
            anim.SetBool(ANIMATION_DEAD, false);
        }

    }






































}//Class
