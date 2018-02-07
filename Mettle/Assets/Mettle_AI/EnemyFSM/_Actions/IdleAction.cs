using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Idle")]

public class IdleAction : Action {

    public override void Act(StateController controller) {

        Advance(controller);
    }

    private void Advance(StateController controller) {

        // Quaternion rotation to enemy
        Vector3 relativePos = controller.m_PlayerMettle.transform.position - controller.m_Agent.transform.position;
        Quaternion lookRotation = Quaternion.Slerp(controller.m_Agent.transform.rotation,
        Quaternion.LookRotation(relativePos), Time.deltaTime * 4.0f);

        controller.m_Agent.destination = controller.m_Agent.transform.position;
        controller.m_Agent.isStopped = true;
        controller.m_Anim.SetTrigger("Idle");
        controller.m_Agent.transform.rotation = lookRotation;
    }
}
