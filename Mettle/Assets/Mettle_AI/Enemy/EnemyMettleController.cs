using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMettleController : MonoBehaviour {

    NavMeshAgent m_Agent;
    Animator m_Anim;
    [HideInInspector] public GameObject m_Enemy;
    [HideInInspector] public EnemyStats m_EnemyStats;

    Vector2 smoothDeltaPosition = Vector2.zero;

    void Start() {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_Enemy = GameObject.FindWithTag("Player");
        // Enemy m_Agent will lead animation
        m_Agent.updatePosition = false;
        m_Agent.updateRotation = false;

    }

    void Update() {

        // Get npc world position       // Not being used but keeping for reference
        Vector3 worldDeltaPosition = m_Agent.nextPosition - transform.position;
        // Map npc to local space
        float dirX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dirY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dirX, dirY);     // deltaPosition is the local space vector

        // Quaternion rotation to enemy        // This is being used
        Vector3 relativePos = m_Enemy.transform.position - m_Agent.transform.position;
        Quaternion lookRotation = Quaternion.Slerp(m_Agent.transform.rotation, Quaternion.LookRotation(relativePos), Time.deltaTime * 4.0f);
        m_Agent.transform.rotation = lookRotation;
    }

    void OnAnimatorMove() {

        transform.position = m_Agent.nextPosition;

    }
}
