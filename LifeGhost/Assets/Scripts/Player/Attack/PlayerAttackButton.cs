using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttackButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    [SerializeField] private PlayerAttacks playerAttack;

    public void OnPointerDown(PointerEventData data) {
        if (gameObject.name == "AttackButton") {
            playerAttack.AttackButtonPressed();

        }
    }

    public void OnPointerUp(PointerEventData data) {
        if (gameObject.name == "AttackButton") {
            playerAttack.AttackButtonReleased();

        }
    }







































































}//Class
