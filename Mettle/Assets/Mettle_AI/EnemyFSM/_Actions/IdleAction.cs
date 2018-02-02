using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Idle")]

public class IdleAction : Action {

    public override void Act(StateController controller) {

        Advance(controller);
    }

    private void Advance(StateController controller) {
        controller.m_Agent.destination = controller.m_Agent.transform.position;
        controller.m_Agent.isStopped = true;
        controller.m_Anim.SetBool("isAdvancing", false);
        controller.m_Anim.SetBool("isIdle", true);
    }
}
