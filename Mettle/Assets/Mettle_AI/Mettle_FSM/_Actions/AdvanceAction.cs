using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Advance")]

public class AdvanceAction : Action {

    public override void Act(StateController controller) {

        Advance(controller);
    }

    private void Advance(StateController controller) {

    if(controller.chaseTarget.transform.position.magnitude >= controller.mettleStatus.advanceRange && controller.chaseTarget.transform.position.magnitude <= controller.mettleStatus.chaseRange)
        controller.m_Agent.nextPosition = controller.chaseTarget.position;
        controller.m_Anim.rootPosition = controller.m_Agent.nextPosition;
        controller.m_Agent.isStopped = false;
        controller.m_Anim.SetTrigger("Advancing");

    }
}
