using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/ActiveState")]

public class ActiveStateDecision : Decision {

	public override bool Decide (StateController controller){

        bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
        return chaseTargetIsActive;

    }
}
