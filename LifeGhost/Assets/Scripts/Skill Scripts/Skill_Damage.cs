using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Damage : MonoBehaviour {
    [SerializeField] private LayerMask zombieLayer;
    [SerializeField] private float radius;
    [SerializeField] private float damageCount;

    [SerializeField] private GameObject damageEffect;

    private EnemyHealth attackTarget;
    private bool collided;

    private void Update() {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, zombieLayer);
        foreach (Collider c in hits) {
            if (c.isTrigger) {
                continue;
            }

            attackTarget = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;

            if (collided) {
                Instantiate(damageEffect, transform.position, transform.rotation);
                attackTarget.EnemyTakeDamage(damageCount);

            }
        }

    }





















}//Class
