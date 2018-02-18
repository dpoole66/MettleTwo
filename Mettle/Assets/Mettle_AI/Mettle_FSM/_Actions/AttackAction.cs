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
        controller.mettleStatus.attackRange, Color.red);

        // look for player
       if (Physics.SphereCast(controller.m_MettleEye.position, controller.mettleStatus.lookSphereCastRadius,
       controller.m_MettleEye.forward, out hit, controller.mettleStatus.attackRange) && hit.collider.CompareTag("Player"))  {

            //Look at player   
            Quaternion DestRot = Quaternion.LookRotation(controller.chaseTarget.transform.position - controller.chaseTarget.transform.position, Vector3.up);
            controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, controller.chaseTarget.transform.rotation, 90.0f * Time.deltaTime);


            //check countdown
            //controller.CheckIfCountDownElapsed(controller.mettleStatus.attackRate);


            if (controller.CheckIfCountDownElapsed(controller.mettleStatus.attackRate)) {


                // Stop enemy
                controller.m_Agent.isStopped = true;
                controller.m_Anim.SetTrigger("Attacking");

            }


       }


    }
}
    


