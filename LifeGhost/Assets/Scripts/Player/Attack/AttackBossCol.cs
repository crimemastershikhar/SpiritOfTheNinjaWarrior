using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBossCol : MonoBehaviour {

    [SerializeField] private LayerMask bossLayer;
    [SerializeField] private float radius;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float damageCount;

    [SerializeField] GameObject attackEffect;

    private BossHealth bossHealth;
    private bool collided;

    private void Update() {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, bossLayer);
        foreach (Collider c in hits) {
            if (c.isTrigger) {
                continue;
            }
            collided = true;
            bossHealth = c.gameObject.GetComponent<BossHealth>();
            if (collided) {
                Instantiate(attackEffect, hitPoint.position, hitPoint.rotation);
                bossHealth.BossTakeDamage(damageCount);

            }
        }

    }





























































}//Class
