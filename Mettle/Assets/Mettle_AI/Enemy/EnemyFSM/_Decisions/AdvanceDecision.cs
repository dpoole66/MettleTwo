using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/Advance")]

public class AdvanceDecision : Decision {

    public override bool Decide(StateController controller) {

        bool targetVisible = Advance(controller);
        return targetVisible;

    }

    private bool Advance(StateController controller) {

        RaycastHit hit;

        Debug.DrawRay(controller.m_MettleEye.position, controller.m_MettleEye.forward.normalized *
        controller.enemyStats.lookRange, Color.gray);

        if (Physics.SphereCast(controller.m_MettleEye.position, controller.enemyStats.lookSphereCastRadius,
            controller.m_MettleEye.forward, out hit, controller.enemyStats.advanceRange) && hit.collider.CompareTag("Player")) {

            controller.chaseTarget = hit.transform;
         
            return true;

        } else
            return false;
    }
}
