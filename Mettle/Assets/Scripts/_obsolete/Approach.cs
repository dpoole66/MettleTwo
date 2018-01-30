using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Approach : MonoBehaviour {

    public Transform EnemyMettle;

    Rigidbody m_Rigidbody;
    Animator m_Animator;
    NavMeshAgent m_Agent;
    Vector3 m_Destination;
    bool isApproaching;
    public float m_Distance;
    GameObject  m_MettleEnemy;


    // Use this for initialization
    void Start () {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Destination = m_Agent.destination;

    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(m_Destination, EnemyMettle.position) > m_Distance) {

            isApproaching = true;
            m_Animator.SetBool("Approaching", isApproaching);
            Advance();

        } else if (Vector3.Distance(m_Destination, EnemyMettle.position) < m_Distance) {

            isApproaching = false;
            m_Animator.SetBool("Approaching", isApproaching);
            //Stop();

        } 


	}

    void Advance() {

        m_Destination = EnemyMettle.position;
        m_Agent.destination = m_Destination;

    }

    void Stop(){

        m_Destination = m_Agent.transform.position;
        m_Agent.SetDestination(m_Destination);

    }
}
