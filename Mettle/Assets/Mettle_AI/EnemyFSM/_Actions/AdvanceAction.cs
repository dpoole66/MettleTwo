using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Advance")]

public class AdvanceAction : Action {

    public override void Act(StateController controller) {

        Advance(controller);
    }

    private void Advance(StateController controller) {
        controller.m_Agent.destination = controller.chaseTarget.position;
        controller.m_Agent.isStopped = false;
        controller.m_Anim.SetBool("isAdvancing", true);
        controller.m_Anim.SetBool("isIdle", false);
    }
}
