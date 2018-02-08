using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MettlePlayer
{ 

    public class PlayerStateController : MonoBehaviour {

        //-------------Fields and Methods

        NavMeshAgent m_Agent = null;
        Animator m_Anim = null;
        GameObject m_Enemy = null;
        public PlayerController M_Character { get; private set; }
        private Transform m_EnemyLoc;



        void Awake() {

            m_Agent = GetComponent<NavMeshAgent>();
            m_Anim = GetComponent<Animator>();
            M_Character = GetComponent<PlayerController>();       
        }


        void Start() {

            CurrentState = PLAYER_STATE.IDLE;
            m_Enemy = GameObject.Find("MettleNPC(Clone)");
            m_EnemyLoc = m_Enemy.GetComponent <Transform>() ;

        }

        //-------------Player finite state machine

        public enum PLAYER_STATE { IDLE, CHASE, ATTACK, DEFEND, INJURED, DEAD };

        [SerializeField]
        private PLAYER_STATE currentState = PLAYER_STATE.IDLE;

        // get private currentState from public encapsulation and return corresponding state
        public PLAYER_STATE CurrentState
        {

            get{ return currentState; }
            set
            {
                currentState = value;

                StopAllCoroutines();

                switch(currentState)
                {
                    case PLAYER_STATE.IDLE:
                        StartCoroutine(Player_Idle());
                        break;


                    case PLAYER_STATE.CHASE:
                        StartCoroutine(Player_Chase());
                        break;


                    case PLAYER_STATE.ATTACK:
                        StartCoroutine(Player_Attack());
                        break;


                    case PLAYER_STATE.DEFEND:
                        StartCoroutine(Player_Defend());
                        break;

                    case PLAYER_STATE.INJURED:
                        StartCoroutine(Player_Injured());
                        break;

                    case PLAYER_STATE.DEAD:
                        StartCoroutine(Player_Dead());
                        break;

                }

            }

        }


        public IEnumerator   Player_Idle(){

            while(currentState == PLAYER_STATE.IDLE)
            {

                m_Agent.isStopped = true;
                m_Anim.SetTrigger("Idle");
                Debug.Log("Idle");
                
                // attack  and move input button
                if(Input.GetMouseButtonDown(1)) 
                {

                    CurrentState = PLAYER_STATE.ATTACK;

                    yield break;  
                    
                }  
               
                
                if (Input.GetMouseButtonDown(0)) 
                {

                    CurrentState = PLAYER_STATE.CHASE;

                    yield break;
                }    

                // wait for next frame
                yield return null;
             }           
        }

        public IEnumerator Player_Chase() {

            while(currentState == PLAYER_STATE.CHASE)
            {
                float distance = Vector3.Distance(m_EnemyLoc.position, m_Agent.transform.position);    
         
                m_Agent.isStopped = false;
                m_Anim.SetTrigger("Walking");    
                Debug.Log("Chase");

                //Wait until path is computed
                while (m_Agent.pathPending)
                    yield return null;

                // Once Player is at destination
                if (m_Agent.remainingDistance <= m_Agent.stoppingDistance) 
                {

                    CurrentState = PLAYER_STATE.IDLE;

                    yield break;
                }

                yield return null;
             }

        }

        public IEnumerator Player_Attack() {

            while (currentState == PLAYER_STATE.ATTACK) {

                m_Anim.SetTrigger("Attacking");
                Debug.Log("Attack");

                yield return new WaitForSeconds(2.0f);

                CurrentState = PLAYER_STATE.IDLE;
  
            }

            yield return null;

        }

        public IEnumerator Player_Injured() {

            while (currentState == PLAYER_STATE.INJURED) {
                yield return null;
            }

            yield break;

        }

        public IEnumerator Player_Defend() {

            while (currentState == PLAYER_STATE.DEFEND) {
                yield return null;
            }

            yield break;

        }

        public IEnumerator Player_Dead() {

            while (currentState == PLAYER_STATE.DEAD) {
                yield return null;
            }

            yield break;

        }

      //-------------End Player state machine

 
    }

}
