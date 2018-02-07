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

        // look for player
        if (Physics.SphereCast(controller.m_MettleEye.position, controller.enemyStats.lookSphereCastRadius,
        controller.m_MettleEye.forward, out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("Player"))

        // Stop enemy
        controller.m_Agent.isStopped = true;

        // Turn off chaseing animation
        controller.m_Anim.ResetTrigger("Chaseing");

        //check countdown
        controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate);


        if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackRate) ) {
   
            controller.m_Anim.SetTrigger("Attacking");

        }

    }
}
    


