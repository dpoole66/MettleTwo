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

    // positions and smoothing for movement
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    private void Start()
    {
        // get the components on the object we need ( should not be null due to require component so no need to check )
        m_Agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_Character = GetComponent<ThirdPersonMettle>();
        m_Enemy = GameObject.FindWithTag("Enemy");

        // for Player m_Agent will follow animation so allow updates
        m_Agent.updateRotation = true;
        m_Agent.updatePosition = true;

    }

    private void Update()
    {

    if(m_Enemy != null){

                Debug.Log("Enemy Detected");

        }

        // Get player world position
        Vector3 worldDeltaPosition = m_Agent.nextPosition - m_Anim.rootPosition;
        // Map npc to local space
        float dirX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dirY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dirX, dirY);     // deltaPosition is the local space vector

        //  filter the movement by returning the smallest value of 2 inputs, 1 and time/.# seconds
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);         // local pos after smoothing

        //Update velocity with time advance
        if (Time.deltaTime > 1e-5f) {

            velocity = smoothDeltaPosition / Time.deltaTime;

        }

        bool isMoving = velocity.magnitude > 0.5f && m_Agent.remainingDistance > m_Agent.radius;

        // Send local space coords to the animator
        m_Anim.SetBool("Moving", isMoving);
        m_Anim.SetFloat("Turn", dirX);
        m_Anim.SetFloat("Forward", dirY);

        // Quaternion rotation to enemy
        Vector3 relativePos = m_Enemy.transform.position - m_Agent.transform.position;
        Quaternion lookRotation = Quaternion.Slerp(m_Agent.transform.rotation, Quaternion.LookRotation(relativePos), Time.deltaTime * 4.0f);

        // Talk to PlaceTargetWithMouse
        if (target != null) {
            m_Agent.SetDestination(target.position);
        }

         //Idle
        if (m_Agent.remainingDistance <= m_Agent.stoppingDistance) {
            
            m_Agent.isStopped = true;
            m_Character.Move(Vector3.zero, false, false);
            m_Anim.SetTrigger("Idle");
            m_Agent.transform.rotation = lookRotation;


        } else {           //Walk
            m_Agent.isStopped = false;    
            m_Character.Move(m_Agent.desiredVelocity, false, false);
            m_Anim.SetTrigger("Walking");
        }

    }


    public void SetTarget(Transform target)
    {
        this.target = target;
    }

}

