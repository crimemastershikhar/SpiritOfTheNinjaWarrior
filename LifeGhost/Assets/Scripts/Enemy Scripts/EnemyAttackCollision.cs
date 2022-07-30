using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary: This script is used to detect the collision b/w player and zombie attack points 

public class EnemyAttackCollision : MonoBehaviour {

    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private Transform hitPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private bool collided;

    [SerializeField] private float damageCount;

    private void Update() {
        Collider[] hits = Physics.OverlapSphere(hitPoint.position, radius, playerLayer);
        foreach (Collider c in hits) {
            if (c.isTrigger)                              //Player made not trigger
                continue;

            collided = true;

            if (collided) {
                playerHealth.TakeDamage(damageCount);

            }

        }

    }









































}//Class
