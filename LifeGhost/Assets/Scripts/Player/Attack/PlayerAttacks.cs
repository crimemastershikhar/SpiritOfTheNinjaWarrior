using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSource;
    
    //Animation States
    private string ANIMATION_ATTACK = "Attack";
    private string ANIMATION_SKILL1 = "Skill1";
    private string ANIMATION_SKILL2 = "Skill2";
    private string ANIMATION_SKILL3 = "Skill3";

    private bool s1_NotUsed;
    private bool s2_NotUsed;
    private bool s3_NotUsed;
    
    [SerializeField]
    private Transform skillOne_Point;    //Instantiate effect prefab
    [SerializeField]
    private Transform skillTwo_Point;

    [SerializeField]
    private AudioClip skillOneMusic1;
    [SerializeField]
    private AudioClip skillOneMusic2;
    [SerializeField]
    private AudioClip skillTwoMusic;
    [SerializeField]
    private AudioClip skillThreeMusic;
    [SerializeField]
    private AudioClip playerSkillOneSound;


    [SerializeField] 
    private GameObject skillOne_EffectPrefab;
    [SerializeField] 
    private GameObject skillOne_DamagePrefab;
    [SerializeField] 
    private GameObject skillTwo_EffectPrefab;
    [SerializeField] 
    private GameObject skillTwo_DamagePrefab;
    [SerializeField]
    private GameObject skillThree_EffectPrefab;

    //Below 1-8 to instantiate damage prefab
    [SerializeField]
    private Transform skillOnePoint_1;
    [SerializeField]
    private Transform skillOnePoint_2;
    [SerializeField]
    private Transform skillOnePoint_3;
    [SerializeField]
    private Transform skillOnePoint_4;
    [SerializeField]
    private Transform skillOnePoint_5;
    [SerializeField]
    private Transform skillOnePoint_6;
    [SerializeField]
    private Transform skillOnePoint_7;
    [SerializeField]
    private Transform skillOnePoint_8;
    [SerializeField]
    private Transform skillTwoPoint_1;
    [SerializeField]
    private Transform skillTwoPoint_2;
    [SerializeField]
    private Transform skillTwoPoint_3;
    [SerializeField]
    private Transform skillTwoPoint_4;
    [SerializeField]
    private Transform skillTwoPoint_5;
    [SerializeField]
    private Transform skillTwoPoint_6;
    [SerializeField]
    private Transform skillThreePoint_1;
    [SerializeField]
    private Transform skillThreePoint_2;
    [SerializeField]
    private Transform skillThreePoint_3;
    [SerializeField]
    private Transform skillThreePoint_4;
    [SerializeField]
    private Transform skillThreePoint_5;

    /*[SerializeField] private Transform[] allSkillPoints;*/

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        s1_NotUsed = true;
        s2_NotUsed = true;
        s3_NotUsed = true;
    }

    private void Update()
    {
        HandleButtonPresses();
    }

    private void HandleButtonPresses()
    {
        if (Input.GetKeyDown(KeyCode.E))
            anim.SetBool(ANIMATION_ATTACK, true);

        if (Input.GetKeyUp(KeyCode.E))
            anim.SetBool(ANIMATION_ATTACK, false);
        
        if(Input.GetKeyDown(KeyCode.J))
            if (s1_NotUsed)
            {
                s1_NotUsed = false;
                anim.SetBool(ANIMATION_SKILL1, true);
                StartCoroutine(ResetSkills(1));
            }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (s2_NotUsed)
            {
                s2_NotUsed = false;
                anim.SetBool(ANIMATION_SKILL2, true);
                StartCoroutine(ResetSkills(2));
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (s3_NotUsed)
            {
                s3_NotUsed = false;
                anim.SetBool(ANIMATION_SKILL3, true);
                StartCoroutine(ResetSkills(3));
            }
        }
    }

    IEnumerator ResetSkills(int skill)
    {
        yield return new WaitForSeconds(3f);
        switch (skill)
        {
            case 1:
                s1_NotUsed = true;
                break;
            case 2:
                s2_NotUsed = true;
                break;
            case  3:
                s3_NotUsed = true;
                break;
        }
    }
    
    //Skill 1 Effects
    void SkillOne(bool skillOne)
    {
        if (skillOne)
        {
            Instantiate(skillOne_EffectPrefab, skillOne_Point.position, skillOne_Point.rotation);
            audioSource.PlayOneShot(skillOneMusic1);
            StartCoroutine(SkillOneCoroutine());
        }
    }
    
    void SkillOneEnd(bool skillOneEnd)
    {
        if(skillOneEnd)
            anim.SetBool(ANIMATION_SKILL1, false);
        
    }

    void SkillOneSound(bool play)
    {
        if (play)
            audioSource.PlayOneShot(playerSkillOneSound);
        
    }

    IEnumerator SkillOneCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_1.position, skillOnePoint_1.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_2.position, skillOnePoint_2.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_3.position, skillOnePoint_3.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_4.position, skillOnePoint_4.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_5.position, skillOnePoint_5.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_6.position, skillOnePoint_6.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_7.position, skillOnePoint_7.rotation);
        Instantiate(skillOne_DamagePrefab, skillOnePoint_8.position, skillOnePoint_8.rotation);
        /*Instantiate(skillOne_DamagePrefab, allSkillPoints[1].position, allSkillPoints[1].rotation);*/
    }
    
    //Skill 2 Effects
    void SkillTwo(bool skillTwo)
    {
        if (skillTwo)
        {
            Instantiate(skillTwo_EffectPrefab, skillTwo_Point.position, skillTwo_Point.rotation);
            audioSource.PlayOneShot(skillTwoMusic);
            StartCoroutine(SkillTwoCoroutine());
        }
    }

    void SkillTwoEnd(bool skillTwoEnd)
    {
        if(skillTwoEnd)
            anim.SetBool(ANIMATION_SKILL2, false);
    }
    
    /*void SkillTwoSound(bool play)
    {
        if(play)
            audioSource.PlayOneShot();
    }*/

    IEnumerator SkillTwoCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_1.position, skillTwoPoint_1.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_2.position, skillTwoPoint_2.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_3.position, skillTwoPoint_3.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_4.position, skillTwoPoint_4.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_5.position, skillTwoPoint_5.rotation);
        Instantiate(skillTwo_DamagePrefab, skillTwoPoint_6.position, skillTwoPoint_6.rotation);
        
    }
    
    // Skill 3 Effects

    void SkillThree(bool skillThree)
    {
        if (skillThree)
        {
            Instantiate(skillThree_EffectPrefab, skillThreePoint_1.position, skillThreePoint_1.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_2.position, skillThreePoint_2.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_3.position, skillThreePoint_3.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_4.position, skillThreePoint_4.rotation);
            Instantiate(skillThree_EffectPrefab, skillThreePoint_5.position, skillThreePoint_5.rotation);
            /*audioSource.PlayOneShot(skillThreeMusic);*/

        }
    }

    void SkillThreeEnd(bool skillThreeEnd)
    {
        if(skillThreeEnd)
            anim.SetBool(ANIMATION_SKILL3, false);
    }


    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}