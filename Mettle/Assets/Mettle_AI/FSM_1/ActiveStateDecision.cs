using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/ActiveState")]

public class ActiveStateDecision : Decision {

	public override bool Decide (StateController controller){

        bool m_EnemyMettleIsActive = controller.m_EnemyMettle.gameObject.activeSelf;
        return m_EnemyMettleIsActive;

    }
}
