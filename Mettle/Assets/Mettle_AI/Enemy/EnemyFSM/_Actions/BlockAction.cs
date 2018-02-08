using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Actions/Block")]

public class BlockAction : Action {

    public override void Act(StateController controller) {

            Block(controller);

    }


    private void Block(StateController controller) {

        controller.m_Agent.transform.LookAt(controller.m_PlayerMettle.transform);
        controller.m_Anim.SetTrigger("Defending");
    }

    
}
