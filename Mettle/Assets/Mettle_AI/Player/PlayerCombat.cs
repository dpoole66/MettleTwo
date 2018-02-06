using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(ThirdPersonMettle))]
public class PlayerCombat : MonoBehaviour {

    public MettleStats m_PlayerStats;       
    [HideInInspector] public NavMeshAgent m_Agent;
   [HideInInspector] public GameObject m_Enemy;    
    [HideInInspector] public Animator m_Anim;
    

    // Use this for initialization
    void Start () {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Enemy = GameObject.Find("MettleNPC(Clone)");
        m_Anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && m_Enemy != null) {

            Attack();

        }

    }

    public void Attack() {
        float distance = Vector3.Distance(m_Agent.transform.position, m_Enemy.transform.position);
        if (m_Agent.isStopped == true && distance <= m_PlayerStats.attackRange) {

            m_Anim.SetTrigger("Attacking");

        } 

    }
}
