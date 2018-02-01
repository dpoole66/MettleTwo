using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Attack")]

public class AttackAction : Action {

    public override void Act(StateController controller) {
        Attack(controller);
    }

    private void Attack(StateController controller) {

        RaycastHit hit;

        Debug.DrawRay(controller.m_MettleEye.position, controller.m_MettleEye.forward.normalized *
        controller.enemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.m_MettleEye.position, controller.enemyStats.lookSphereCastRadius,
        controller.m_MettleEye.forward, out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("Player"))


        if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate)) {

            controller.m_Anim.SetBool("isAttacking", true);
            controller.m_Anim.SetBool("isChaseing", false);

            } else {

                controller.m_Anim.SetBool("isAttacking", false);
       
            }

    }
}
    


