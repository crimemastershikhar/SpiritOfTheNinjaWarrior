using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordTrail : MonoBehaviour
{
    private MeleeWeaponTrail weaponTrail;

    [SerializeField] private Transform sword;
    [SerializeField] private GameObject hitPoint;
    [SerializeField] private GameObject slashThreeEffectPrefab;
    [SerializeField] private Transform slashThreePoint;   //point to spawn prefab

    [SerializeField] private AudioClip swordHit1;
    [SerializeField] private AudioClip swordHit2;
    [SerializeField] private AudioClip earthHitMusic;    //called in threeEffect
    [SerializeField] private AudioClip jiaohanSheng;     //Storing by name of clip 

    private AudioSource audioSource;

    private void Awake()
    {
        weaponTrail = sword.gameObject.GetComponent<MeleeWeaponTrail>();
        audioSource = GetComponent<AudioSource>();
    }

    void SlashOneWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);
            audioSource.PlayOneShot(swordHit1);
        }
    }
    
    void SlashOneWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);
        }
    }
    
    void SlashTwoWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);
            audioSource.PlayOneShot(swordHit2);
        }
    }
    
    void SlashTwoWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);
        }
    }
    
    void SlashThreeWeaponTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);
            audioSource.PlayOneShot(jiaohanSheng);
        }
    }
    
    void SlashThreeWeaponTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);
        }
    }

    void SlashThreeEffect(bool show)
    {
        if (show)
        {
            Instantiate(slashThreeEffectPrefab, slashThreePoint.position, slashThreePoint.rotation);
            audioSource.PlayOneShot((earthHitMusic));
            
        }
    }
}
