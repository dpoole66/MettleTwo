using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Mettle_AI/Decisions/P_Alert")]

public class P_AlertDecision : Decision {

	public override bool Decide(StateController controller){

        bool isAlerted = Alerted(controller);
        return isAlerted;

    }


    private bool Alerted(StateController controller) {

        var range = Vector3.Distance(controller.chaseTarget.transform.position, controller.m_Agent.transform.position);

        if (range <= controller.mettleStatus.alertRange) {

            controller.m_Anim.SetTrigger("Alert");

            return true;

        } else
            return false;

    }

}
