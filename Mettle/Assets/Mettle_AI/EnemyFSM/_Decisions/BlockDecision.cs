using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/Block")]

public class BlockDecision : Decision {

	public override bool Decide(StateController controller){

        bool blockAttack = Block(controller);
        return blockAttack;

    }

    private bool Block(StateController controller){

        Debug.DrawRay(controller.m_MettleEye.position, controller.m_MettleEye.forward.normalized *
            controller.enemyStats.attackRange, Color.white);

        if (controller.m_PlayerAttacking == true) {

            return true;

        } else
            return false;


    }

}
