using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartMove : MonoBehaviour {

    [SerializeField] private BossAI bossAI;

    private SphereCollider col;

    private void Awake() {
        col = GetComponent<SphereCollider>();

    }

    private void OnTriggerEnter(Collider target) {
        if (target.tag == "Player") {
            bossAI.enabled = true;
            col.enabled = false;
        }

    }

}//Class
