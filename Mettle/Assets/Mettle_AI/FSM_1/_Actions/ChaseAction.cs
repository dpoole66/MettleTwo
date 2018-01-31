﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Mettle_AI/Actions/Chase")]

public class ChaseAction : Action {

public override void Act (StateController controller){

        Chase(controller);

}	

private void Chase(StateController controller){

        controller.m_Agent.destination = controller.chaseTarget.position;
        controller.m_Agent.isStopped = false;
        //controller.m_Anim.SetBool("isChaseing", true);

    }

}
