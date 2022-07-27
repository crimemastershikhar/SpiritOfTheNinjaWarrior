using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour /*, IDamagable*/ {
    public float realHealth { get; private set; }

    private BossHealth bossHealth;
    /*    [SerializeField] private Transform bossTransform;*/

    private Slider healthSlider;
    private Text healthText;

    private string ANIMATION_DEAD = "Dead";
    private string ANIMATION_ATTACK = "Attack";
    private string ANIMATION_VICTORY = "Victory";
    private string BASE_LAYER_DYING = "Base Layer.Dying";
    private string BASE_LAYER_VICTORY = "Base Layer.Victory";

    private Animator anim;
    private bool playerDead;
    private bool victory;
    private bool playerBeHit;

    private void Awake() {
        anim = GetComponent<Animator>();
        /*        bossHealth = bossTransform.gameObject.GetComponent<BossHealth>();*/

    }

    private void Update() {
        if (realHealth <= 0) {
            realHealth = 0;
            PlayerDying();

        }

        if (playerDead) {
            StopPlayerDeadAnimation();

        }

        /*        if (bossHealth.realHealth <= 0) {
                    Victory();

                }*/

        if (victory) {
            StopVictoryAnimation();

        }

    }

    void PlayerDying() {
        playerDead = true;
        anim.SetBool(ANIMATION_DEAD, true);
        anim.SetBool(ANIMATION_ATTACK, false);                   //Precaution. can turn off later

    }

    void StopPlayerDeadAnimation() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_DYING)) {
            anim.SetBool(ANIMATION_DEAD, false);

        }
    }

    public void TakeDamage(float amount) {                       //Use Interface IDamagable
        realHealth -= amount;

        if (realHealth <= 0)
            realHealth = 0;

        if (amount > 0) {
            //healthText.text = realHealth.ToString()
            healthSlider.value = realHealth;
            playerBeHit = true;

        }
    }

    void Victory() {
        anim.SetBool(ANIMATION_VICTORY, true);
        victory = true;

    }

    void StopVictoryAnimation() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(BASE_LAYER_VICTORY))
            anim.SetBool(ANIMATION_VICTORY, false);

    }






















}//Class
