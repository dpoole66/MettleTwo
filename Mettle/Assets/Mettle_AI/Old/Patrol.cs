using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : M_One_BaseFSM {

   GameObject[] waypoints;
    int currentWP;

    private void Awake() {

        waypoints = GameObject.FindGameObjectsWithTag("waypoint");

    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    base.OnStateEnter(animator, stateInfo,layerIndex);
        currentWP = 0;
	
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (waypoints.Length == 0) return;  

        if(Vector3.Distance(waypoints[currentWP].transform.position, m_MettleOne.transform.position) < 3.0f){

            currentWP++;
            if(currentWP >-waypoints.Length){
                currentWP = 0;            
            }

            // rotate to face current waypoint
            var direction = waypoints[currentWP].transform.position - m_MettleOne.transform.position;
            m_MettleOne.transform.rotation = Quaternion.Slerp(m_MettleOne.transform.rotation, Quaternion.LookRotation(direction), 2.0f * Time.deltaTime);
            Debug.Log(direction);
            //Move forward along z
            m_MettleOne.transform.Translate(0, 0, Time.deltaTime * 2.0f);

            Debug.Log(currentWP);

        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
