using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/P_Idle")]

public class P_IdleAction : Action {

    public override void Act(StateController controller) {

        P_Idle(controller);
    }

    private void P_Idle(StateController controller) {
  
        controller.m_Agent.isStopped = true;
        controller.m_Anim.SetTrigger("Idle");

        if (controller.m_Agent.remainingDistance <= controller.m_Agent.stoppingDistance) {

            Quaternion DestRot = Quaternion.LookRotation(controller.chaseTarget.transform.position - controller.m_Agent.transform.position, Vector3.up);
            controller.m_Agent.transform.rotation = Quaternion.RotateTowards(controller.m_Agent.transform.rotation, DestRot, 180.0f * Time.deltaTime);

        }
    }

}
