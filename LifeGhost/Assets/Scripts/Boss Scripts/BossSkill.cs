using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : MonoBehaviour {
    [SerializeField] private GameObject skill3;
    [SerializeField] private GameObject skill3Point;

    private GameObject skill1;
    /*    [SerializeField] private GameObject skill1_Point_1;
        [SerializeField] private GameObject skill1_Point_2;
        [SerializeField] private GameObject skill1_Point_3;
        [SerializeField] private GameObject skill1_Point_4;
        [SerializeField] private GameObject skill1_Point_5;
        [SerializeField] private GameObject skill1_Point_6;
        [SerializeField] private GameObject skill1_Point_7;
        [SerializeField] private GameObject skill1_Point_8;
        [SerializeField] private GameObject skill1_Point_9;*/

    [SerializeField] private Transform[] skill_Points;

    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject hitPoint;
    private MeleeWeaponTrail swordTrail;

    [SerializeField] private AudioClip earthHit;
    private AudioSource audioSource;


    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        swordTrail = sword.GetComponent<MeleeWeaponTrail>();

    }

    void Skill1(bool execute) {
        if (execute) {
            InstantiatingSkillEffect();
        }

        StartCoroutine(Skill1AfterWait());

    }

    IEnumerator Skill1AfterWait() {
        yield return new WaitForSeconds(1f);

        InstantiatingSkillEffect();

    }

    void Skill3(bool execute) {
        if (execute) {
            Instantiate(skill3, skill3Point.transform.position, skill3Point.transform.rotation);
            audioSource.PlayOneShot(earthHit);

        }
    }

    void SwordSlashAttack(bool isAttacking) {
        if (isAttacking) {
            swordTrail.Emit = true;
            hitPoint.SetActive(true);

        }
    }

    void SwordSlashAttackEnd(bool attackEnd) {
        if (attackEnd) {
            swordTrail.Emit = false;
            hitPoint.SetActive(false);

        }
    }

    void InstantiatingSkillEffect() {
        Instantiate(skill1, skill_Points[0].position, skill_Points[0].rotation);
        Instantiate(skill1, skill_Points[1].position, skill_Points[1].rotation);
        Instantiate(skill1, skill_Points[2].position, skill_Points[2].rotation);
        Instantiate(skill1, skill_Points[3].position, skill_Points[3].rotation);
        Instantiate(skill1, skill_Points[4].position, skill_Points[4].rotation);
        Instantiate(skill1, skill_Points[5].position, skill_Points[5].rotation);
        Instantiate(skill1, skill_Points[6].position, skill_Points[6].rotation);
        Instantiate(skill1, skill_Points[7].position, skill_Points[7].rotation);
        Instantiate(skill1, skill_Points[8].position, skill_Points[8].rotation);
        Instantiate(skill1, skill_Points[9].position, skill_Points[9].rotation);

    }












































}//Class
