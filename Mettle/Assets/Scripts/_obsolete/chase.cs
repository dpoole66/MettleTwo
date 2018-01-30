using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(MettleEnemyController))]
public class chase : MonoBehaviour {
    //public MettleEnemyController m_Character { get; private set; }
    public Transform EnemyMettle; 
    public Transform MettleHead;
    public Transform MettleEye;
    NavMeshAgent m_Agent;
    Animator m_Animator;
    bool inPursuit = false;
    public float speed = 1.0f;

    private void Start() {

        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
       // m_Character = GetComponent<MettleEnemyController>();

    }

    // Rotate Mettle to face Enemy
    void Update() {

        Vector3 direction = EnemyMettle.position - m_Agent.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, m_Agent.transform.forward);

        if (Vector3.Distance(EnemyMettle.position, MettleEye.forward) < 4.0f && (angle < 50 || inPursuit)) {
  
            // Rotation
            m_Agent.transform.rotation = Quaternion.Slerp(m_Agent.transform.rotation, Quaternion.LookRotation(direction), 0.2f);

            // detect movement
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;
            // combine straffe/translation for Translation
            transform.Translate(straffe, 0, translation);
            if (translation != 0) {
                m_Animator.SetBool("isMoveing", true);
                //m_Animator.SetBool("isIdle", false);
            } else {
                m_Animator.SetBool("isMoveing", false);
                // m_Animator.SetBool("isIdle", true);
            }

            // Switch Mechanim
            m_Animator.SetBool("isIdle", false);

            // set inPursuit
            inPursuit = true;
            // Advance Mettle toward Enemy 
            if (direction.magnitude > 7.0f) {
                m_Agent.destination = EnemyMettle.transform.position;
                m_Agent.isStopped = false;   
                //m_Character.Move(m_Agent.desiredVelocity, false, false);
                //m_Animator.SetBool("isMoveing", true);
                m_Animator.SetBool("isAttacking", false);
                m_Animator.SetBool("isIdle", false);
                m_Animator.SetBool("isLooking", true);
                m_Animator.SetBool("isEnGuarde", false);
            } else if (direction.magnitude < 4.0f){
                //m_Animator.SetBool("isMoveing", true);
                m_Animator.SetBool("isAttacking", false);
                m_Animator.SetBool("isIdle", false);
                m_Animator.SetBool("isLooking", true);
                m_Animator.SetBool("isEnGuarde", true);
            } else if (direction.magnitude < 1.33f) {       
                m_Agent.isStopped = true;
                //m_Animator.SetBool("isMoveing", false);
                m_Animator.SetBool("isAttacking", true);
                m_Animator.SetBool("isIdle", false);
                m_Animator.SetBool("isLooking", true);
                m_Animator.SetBool("isEnGuarde", false);
            }

        } else  {
            m_Agent.isStopped = true;
            //m_Animator.SetBool("isMoveing", false);
            m_Animator.SetBool("isAttacking", false);
            m_Animator.SetBool("isIdle", true);
            m_Animator.SetBool("isLooking", false);
            inPursuit = false;
        }
            
    }
    }


