using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {
    public Transform m_MettlePrime;
    public Transform m_MettleOneHead;
    public float MoveSpeed = 1.0f;

    public Slider m_HealthBar;

    static Animator m_Anim;
    NavMeshAgent m_Agent;
    Vector3 destination;
    bool pursuing = false;

	// Use this for initialization
	void Start () {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        destination = m_Agent.destination;
        m_Anim.SetBool("isIdle", false);
        m_Anim.SetBool("isAdvancing", false);
        m_Anim.SetBool("isAttacking", false);

        m_HealthBar.value = 100;
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (m_HealthBar.value <= 0) 
        return;

        Vector3 direction = m_MettlePrime.position - this.transform.position;
        direction.y = 0;

        float angle = Vector3.Angle(direction, m_MettleOneHead.forward);

        if (Vector3.Distance(m_MettlePrime.position, this.transform.position) < 7.0f && (angle < 45.0f || pursuing)) {

            pursuing = true;

            m_Agent.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.03f);
            m_Anim.SetBool("isIdle", false);

            if (direction.magnitude > 2.0f) {
                this.transform.Translate(0, 0, 0.05f);
                m_Anim.SetBool("isIdle", false);
                m_Anim.SetBool("isAdvancing", true);
                m_Anim.SetBool("isAttacking", false);

            } else if (direction.magnitude < 2.0f) {
                m_Anim.SetBool("isIdle", false);
                m_Anim.SetBool("isAdvancing", false);
                m_Anim.SetBool("isAttacking", true);
            }
        } else {
            m_Anim.SetBool("isIdle", true);
            m_Anim.SetBool("isAdvancing", false);
            m_Anim.SetBool("isAttacking", false);

            bool pursuing = false;
        }
    }
}
