using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof(Animator))]
public class LocomotionSimpleAgent : MonoBehaviour {
   
    Animator m_Animator;
    NavMeshAgent m_Agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    void Start() {
        m_Animator = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        m_Agent.updatePosition = false;
    }

    void Update() {
        
    Vector3 worldDeltaPosition = m_Agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && m_Agent.remainingDistance > m_Agent.radius;

        // Update animation parameters
        m_Animator.SetBool("move", shouldMove);
        m_Animator.SetFloat("Turn", velocity.x);
        m_Animator.SetFloat("Forward", velocity.y);


        GetComponent<LookAtEnemy>().lookAtTargetPosition = m_Agent.steeringTarget + transform.forward;

        LookAtEnemy lookAt = GetComponent<LookAtEnemy>();
        if (lookAt)  {
            lookAt.lookAtTargetPosition = m_Agent.steeringTarget + transform.forward;
        }
            
    }

    
    void OnAnimatorMove() {
        // Update position to agent position
        transform.position = m_Agent.nextPosition;
    }
    
}
