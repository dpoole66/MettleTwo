using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Block")]

public class BlockAction : Action {

    public override void Act(StateController controller) {

            Block(controller);

    }


    private void Block(StateController controller) {
        /*
        RaycastHit hit;

        Debug.DrawRay(controller.m_MettleEye.position, controller.m_MettleEye.forward.normalized *
        controller.enemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.m_MettleEye.position, controller.enemyStats.lookSphereCastRadius,
        controller.m_MettleEye.forward, out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("Player"))

        controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate);

        // rotate toward player
        controller.m_Agent.transform.LookAt(controller.chaseTarget);
         */
        if (controller.m_PlayerAttacking == true) {

            controller.m_Anim.SetBool("isBlocked", true);

        }

    }
}
