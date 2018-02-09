using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MettlePlayer
{

    public class PlayerInput : MonoBehaviour {

        public PlayerController M_Character { get; private set; }      //public read access / private write access
        [HideInInspector] public NavMeshAgent m_Agent { get; private set; }
        private Transform m_MoveToTarget;


        private void Start() {

            M_Character = GetComponent<PlayerController>();
            m_Agent = GetComponent<NavMeshAgent>();

            m_Agent.updateRotation = false;
            m_Agent.updatePosition = true;

        }

        // Update is called once per frame
        private void Update() {

            if (m_MoveToTarget != null) {

                m_Agent.SetDestination(m_MoveToTarget.position);

                if (m_Agent.remainingDistance > m_Agent.stoppingDistance)
                    M_Character.Move(m_Agent.desiredVelocity, true);                // added "true" for m_Moving bool
                else
                    M_Character.Move(Vector3.zero, false);           /// false m_Moving

            }



        }

        public void SetTarget(Transform target){

            this.m_MoveToTarget = target;

        }
    }
}


