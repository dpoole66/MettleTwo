using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Advance")]

public class AdvanceAction : Action {

    public override void Act(StateController controller) {

        Advance(controller);
    }

    private void Advance(StateController controller) {

    if(controller.m_PlayerMettle.transform.position.magnitude >= controller.enemyStats.advanceRange && controller.m_PlayerMettle.transform.position.magnitude <= controller.enemyStats.chaseRange)
        controller.m_Agent.nextPosition = controller.chaseTarget.position;
        controller.m_Anim.rootPosition = controller.m_Agent.nextPosition;
        controller.m_Agent.isStopped = false;
        controller.m_Anim.SetTrigger("Advancing");

    }
}
