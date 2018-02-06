using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementEnemy : MonoBehaviour {

    NavMeshAgent m_Agent;
    Animator m_Anim;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;


    void Start () {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Anim = GetComponent<Animator>();
        m_Agent.updatePosition = false;
        m_Agent.updateRotation = false;

    }
	
	void Update () {

        // Get npc world position
        Vector3 worldDeltaPosition = m_Agent.nextPosition - transform.position;
        // Map npc to local space
        float dirX = Vector3.Dot(transform.right, worldDeltaPosition);
        float dirY = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dirX, dirY);     // deltaPosition is the local space vector

        //  filter the movement by returning the smallest value of 2 inputs, 1 and time/.# seconds
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);         // local pos after smoothing

        //Update velocity with time advance
        if(Time.deltaTime > 1e-5f)      {

            velocity = smoothDeltaPosition / Time.deltaTime;

        }

        bool isMoving = velocity.magnitude > 0.5f && m_Agent.remainingDistance > m_Agent.radius;

        // Send local space coords to the animator
        m_Anim.SetBool("moving", isMoving);
        m_Anim.SetFloat("turn", dirX);
        m_Anim.SetFloat("forward" ,  dirY);

        //GetComponent<LookAt>().lookAtTargetPosition = m_Agent.steeringTarget + transform.forward;

	}

    void OnAnimatorMove() {

        transform.position = m_Agent.nextPosition;

    }
}
