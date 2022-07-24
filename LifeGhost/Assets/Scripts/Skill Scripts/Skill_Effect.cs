using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

//class summary: To detect with which game object this fireball is colliding i.e. Zombies or the boss
public class Skill_Effect : MonoBehaviour
{
    [SerializeField] private LayerMask ignoreLayers;

    [SerializeField] private GameObject skillEffectPrefab;
    [SerializeField] private float radius;

    private bool collided = false;

    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, ~ignoreLayers);

        foreach (Collider c in hits)
        {
            if(c.isTrigger)
                continue;

            collided = true;
        }

        if (collided)
        {
            Instantiate(skillEffectPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
        }

    }
}
