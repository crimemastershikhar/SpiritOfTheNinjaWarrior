using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillDamage : MonoBehaviour {
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float radius;
    [SerializeField] private float damageCount;

    private bool collided;

    [SerializeField] private PlayerHealth playerHealth;


    private void Update() {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, playerMask);
        foreach (Collider c in hits) {
            continue;
        }
        collided = true;
        if (collided) {
            playerHealth.TakeDamage(damageCount);
            Destroy(gameObject);

        }
    }


}//Class
