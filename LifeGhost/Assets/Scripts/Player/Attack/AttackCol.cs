using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary: 

public class AttackCol : MonoBehaviour {

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float radius;
    [SerializeField] private GameObject attackEffect;
    [SerializeField] private Transform hitPoint;

    private EnemyHealth enemyHealth;

    private bool collided;
    [SerializeField] private float damageCount;

    private void Update() {
        Collider[] hits = Physics.OverlapSphere(hitPoint.position, radius, enemyLayer);
        foreach (Collider c in hits) {
            if (c.isTrigger) {
                continue;
            }

            enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;

            if (collided) {
                Instantiate(attackEffect, hitPoint.position, hitPoint.rotation);
                enemyHealth.EnemyTakeDamage(damageCount);
            }

        }

    }



















}//Class
