using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MettlePlayer
{

    public class PlayerController : MonoBehaviour {

        [SerializeField] float m_MovingTurnSpeed = 360;             // *Keeping TPC/Unity Standard Assets Editor level speed and rot tuning. May remove later.
        [SerializeField] float m_StationaryTurnSpeed = 180;
        [SerializeField] float m_MoveSpeedMultiplier = 1f;
        [SerializeField] float m_AnimSpeedMultiplier = 1f;

        Rigidbody m_Rigid; 
        Animator m_Anim;

        float m_TurnAmount;
        float m_ForwardAmount;
        bool m_Moving;


        void Start() {

            m_Rigid = GetComponent<Rigidbody>();
            m_Anim = GetComponent<Animator>();

        }

        // Movement w/o jumping or crouching to reduce overhead for unimpleted features
        public void Move(Vector3 move, bool inMotion) {

            if (move.magnitude > 1.0f) {

                move.Normalize();

            }

            move = transform.InverseTransformDirection(move);         // InversTransformDirection to find position not direction
            move = Vector3.ProjectOnPlane(move, Vector3.up);
            m_TurnAmount = Mathf.Atan2(move.x, move.z);     // Get the angle between the move vectors
            m_ForwardAmount = move.z;
            ApplyExtraTurnRotation();       // *Keeping this for now
            inMotion = move.magnitude > 0.1f;                  // Set the Move bool inMotion if we are moving sufficently
            m_Moving = inMotion;                                         // Keeping another bool for now. This may be removed

            UpdateAnimator(move);

        }

        void UpdateAnimator(Vector3 move){

            m_Anim.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);      // using dampTime to smooth against deltaTime
            m_Anim.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
            m_Anim.SetBool("Moving", m_Moving);

            if(m_Moving == true){

                m_Anim.SetTrigger("Walking");

            }      else {

                m_Anim.SetTrigger("Idle");

            }

        }

        void ApplyExtraTurnRotation() {
            // *See above
            float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
            transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);

        }

        public void OnAnimatorMove() {
            // we implement this function to override the default root motion.
            // this allows us to modify the positional speed before it's applied.
            if (Time.deltaTime > 0) {
                Vector3 v = (m_Anim.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

                // we preserve the existing y part of the current velocity.
                v.y = m_Rigid.velocity.y;
                m_Rigid.velocity = v;
            }
        }

    }

    
}
