using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/P_Alert")]

public class P_AlertAction : Action {

    public override void Act(StateController controller) {

        P_Alert(controller);
    
    }

    private void P_Alert(StateController controller){

            controller.m_Anim.SetTrigger("Alert");
    

    }

}
