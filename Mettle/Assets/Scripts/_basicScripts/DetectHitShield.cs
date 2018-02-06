﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHitShield : MonoBehaviour {
    private GameObject m_SwordOwner;  
    Animator m_Anim;
    public string m_PlayerShield;

    // Use this for initialization
    void Awake () {
        m_SwordOwner = GameObject.Find("MettleNPC(Clone)");
        m_Anim = m_SwordOwner.GetComponent<Animator>();
    }

    // Hit Trigger count
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag != m_PlayerShield) {

            return;

        } else {

            m_Anim.SetBool("isAttacking", false);
            Debug.Log("Blocked");

        }

    }
}