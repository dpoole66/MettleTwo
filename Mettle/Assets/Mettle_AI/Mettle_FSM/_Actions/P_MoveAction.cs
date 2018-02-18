using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/P_Move")]

public class P_MoveAction : Action {

    public override void Act(StateController controller) {

        Move(controller);

    }

    private void Move(StateController controller) {
   
            controller.m_Agent.isStopped = false;
            controller.m_Anim.SetTrigger("Walking");
            Debug.Log("Moveing");

    }
}
