using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_DamageBoss : MonoBehaviour {

    [SerializeField] private LayerMask bossLayer;
    [SerializeField] private float radius;
    [SerializeField] private float damageCount;

    private bool collided;
    private BossHealth bossHealth;

    [SerializeField] private GameObject damageEffect;


    private void Update() {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, bossLayer);
        foreach (Collider c in hits) {
            if (c.isTrigger) {
                continue;
            }
            collided = true;
            bossHealth = c.gameObject.GetComponent<BossHealth>();
            if (collided) {
                Instantiate(damageEffect, transform.position, transform.rotation);
                bossHealth.BossTakeDamage(damageCount);
                Destroy(gameObject);

            }
        }

    }























































}//Class
