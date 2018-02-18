using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MettlePlayer;

public class PlayerAttack : MonoBehaviour {

    public int m_MettleNumber = 1;
    public Slider m_P_AimSlider;
    public AudioSource m_AttackAudio;
    public AudioClip m_WieldingClip; // sound playing while attack is chargeing
    public AudioClip m_AttackClip;
    public float m_MinAttackForce = 15.0f;
    public float m_MaxAttackForce = 30.0f;
    public float m_MaxWieldingTime = 0.75f;
    [HideInInspector] public PlayerStateController M_PlayerState { get; private set; }

    //Linking attack to PlayerStateController
    Animator m_Anim;

    private string m_AttackButton;
    private float m_CurrentAttackForce;
    private float m_WieldSpeed;
    private bool m_AttackingNow;
    private float nextAttackTime;

    private void OnEnable() {

            m_CurrentAttackForce = m_MinAttackForce;
            m_P_AimSlider.value = m_MinAttackForce;
         
    }

    void Start () {

        m_AttackButton = "Fire" + m_MettleNumber;

        m_WieldSpeed = (m_MaxAttackForce - m_MinAttackForce) / m_MaxWieldingTime;
        m_Anim = GetComponent<Animator>();


    }
	

	 void Update () {

        //Min value at start
        m_P_AimSlider.value = m_MinAttackForce;

        //when max force and no attack, just attack  anyway
            if(m_CurrentAttackForce >= m_MaxAttackForce && !m_AttackingNow){

                //if we're at max force but havent attacked
                m_CurrentAttackForce = m_MaxAttackForce;    
                Strike(m_CurrentAttackForce, 1);

                }    else if(Input.GetButtonDown(m_AttackButton)){           // Attack has been pressed

                    m_AttackingNow = false;
                    m_CurrentAttackForce = m_MinAttackForce;

                    //Audio feedback
                    m_AttackAudio.clip = m_WieldingClip;
                    m_AttackAudio.Play();

                }else if(Input.GetButton(m_AttackButton) && !m_AttackingNow){            // Attack held but not launched

                    //increase force aund update UI
                    m_CurrentAttackForce += m_WieldSpeed * Time.deltaTime;
                    m_P_AimSlider.value = m_CurrentAttackForce;
 
                }else if(Input.GetButtonUp(m_AttackButton) && !m_AttackingNow){

                        Strike(m_CurrentAttackForce, 1);

                }     
	}

    public void Strike(float attackForce, float attackRate){

        if(Time.time > nextAttackTime){

            m_AttackingNow = true;

            m_AttackAudio.clip = m_AttackClip;
            m_AttackAudio.Play();
  

            //Reset force 
            m_CurrentAttackForce = m_MaxAttackForce;

        }

    }

}
