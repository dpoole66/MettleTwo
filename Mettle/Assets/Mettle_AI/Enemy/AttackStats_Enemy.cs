using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStats_Enemy : MonoBehaviour {

    public AudioClip m_Attacking;
    [HideInInspector] public AudioSource m_NPCAudio;
    [HideInInspector] public Animator m_Anim;

    public float m_MinAttackForce = 15f;     
    public float m_MaxAttackForce = 30f;     
    public float m_MaxChargeTime = 0.75f;

    // Use this for initialization
    void Awake () {
         
        m_Anim = GetComponent<Animator>(); 
        m_NPCAudio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	public void Attack () {

        m_Anim.SetBool("isAttacking", true);
        m_NPCAudio.Play();

    }
}
