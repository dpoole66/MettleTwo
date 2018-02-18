using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/P_Move")]

public class P_MoveDecision : Decision {

    public override bool Decide(StateController controller) {

        bool moveNow = Move(controller);
        return moveNow;

    }

    private bool Move(StateController controller) {

        if (controller.m_Agent.remainingDistance >= controller.m_Agent.stoppingDistance && !controller.m_Agent.pathPending) {

            return true;

        } else

        return false;

    }
}
