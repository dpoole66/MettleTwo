using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Attack")]

public class AttackAction : Action {
    
    public override void Act (StateController controller){
        Attack(controller);
    } 

    private void Attack(StateController controller){
        RaycastHit hit;

        Debug.DrawRay(controller.m_MettleEye.position, controller.m_MettleEye.forward.normalized *
        controller.enemyStats.lookRange, Color.red);

        if (Physics.SphereCast(controller.m_MettleEye.position, controller.enemyStats.lookSphereCastRadius,
        controller.m_MettleEye.forward, out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("MettlePrime")) {
            if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate)) {
                controller.Attack(controller.enemyStats.attackForce, controller.enemyStats.attackRate);
                controller.m_Anim.SetBool("isAttacking", true);

            } else {
                controller.m_Anim.SetBool("isAttacking", false);
            }
        }
    }

}
