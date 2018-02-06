using System;
using UnityEngine;


[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonMettle))]
public class AIMettleControl : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent m_Agent { get; private set; }             
    public ThirdPersonMettle m_Character { get; private set; } 
    private Transform target;
    [HideInInspector] public GameObject m_Enemy;    
    [HideInInspector] public Animator m_Anim;
    [HideInInspector] public MettleStats m_PlayerStats;


    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        m_Agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_Character = GetComponent<ThirdPersonMettle>();
        m_Enemy = GameObject.FindWithTag("Enemy");
        m_Agent.updateRotation = false;
        m_Agent.updatePosition = true;
        //m_Agent.updateUpAxis = true;

    }

    private void Update()
    {

    if(m_Enemy != null){

                Debug.Log("Enemy Detected");

        }

        // Get player world position
        Vector3 worldDeltaPosition = m_Agent.nextPosition - transform.position;
        // Map npc to local space
        float dirX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dirY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dirX, dirY);     // deltaPosition is the local space vector

        // Get angles for rotation
        var rotVal = Vector3.Angle(
        Vector3.ProjectOnPlane(m_Agent.transform.forward, Vector3.up).normalized,
        Vector3.ProjectOnPlane(m_Enemy.transform.position - m_Agent.transform.position, Vector3.up).normalized);

        // Quaternion rotation to enemy
        Vector3 relativePos = m_Enemy.transform.position - m_Agent.transform.position;
        Quaternion lookRotation = Quaternion.Slerp(m_Agent.transform.rotation, Quaternion.LookRotation(relativePos), Time.deltaTime * 4.0f);

        // Talk to PlaceTargetWithMouse
        if (target != null) {
            m_Agent.SetDestination(target.position);
        }

            // Walk to enemy
        if (m_Agent.remainingDistance > m_Agent.stoppingDistance) {
            m_Agent.isStopped = false;    
            m_Character.Move(m_Agent.desiredVelocity, false, false);
            m_Anim.SetTrigger("Walking");

        } else {    
            // Rotate to enemy when stopped
            m_Agent.isStopped = true;
            m_Character.Move(Vector3.zero, false, false);
            m_Anim.SetTrigger("Idle"); 
            m_Agent.transform.rotation = lookRotation;
        }
                                                                                     
    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }

}

