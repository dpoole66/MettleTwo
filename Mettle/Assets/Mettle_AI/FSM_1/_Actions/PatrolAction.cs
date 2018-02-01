using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Patrol")]

public class PatrolAction : Action {

    public override void Act(StateController controller) {

        Patrol(controller);
    }

    private void Patrol(StateController controller) {
        controller.m_Agent.destination = controller.wayPointList[controller.nextWayPoint].position;
        controller.m_Agent.isStopped = false;

        if (controller.m_Agent.remainingDistance <= controller.m_Agent.stoppingDistance && !controller.m_Agent.pathPending) {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;

            controller.m_Anim.SetBool("isPatrolling", true);

            controller.m_NPCAudio.clip = controller.m_Walking;
            controller.m_NPCAudio.Play();

        }    else{

            controller.m_Anim.SetBool("isPatrolling", false);

        }
    }

}
