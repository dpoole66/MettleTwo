using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MOneMovement : MonoBehaviour {

    public Transform m_Enemy;
    public float AwareDistance = 8.0f;
    public float ApproachDistance = 5.0f;
    public float AttackDistance = 1.33f;
    public float ApproachSpeed = 1.0f;
    Animator m_Anim;
    NavMeshAgent m_Agent;

	// Use this for initialization
	void Start () {
        m_Anim = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(m_Enemy.position, this.transform.position) <= AwareDistance) {
            Vector3 direction = m_Enemy.position - this.transform.position;
            direction.y = 0.0f;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.3f);

            m_Anim.SetBool("isIdle", false);

            if (direction.magnitude >= ApproachDistance) {

                this.transform.Translate(0, 0, ApproachSpeed);
                
                m_Anim.SetBool("isAdvancing", true);
                m_Anim.SetBool("isAttacking", false);


            } else {
                m_Anim.SetBool("isAdvancing", false); 
                m_Anim.SetBool("isAttacking", true);  
            }
        } else {
            m_Anim.SetBool("isIdle", true);
            m_Anim.SetBool("isAdvancing", false); 
            m_Anim.SetBool("isAttacking", false);

        }
        
	}
}
