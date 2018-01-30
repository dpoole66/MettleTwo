﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mettle_AI/Decisions/Look")]

public class LookDecision : Decision {

	public override bool Decide(StateController controller){

        bool targetVisible = Look(controller);
        return targetVisible;

    }

    private bool Look(StateController controller){

        RaycastHit hit;

        Debug.DrawRay(controller.m_MettleEye.position, controller.m_MettleEye.forward.normalized *
        controller.enemyStats.lookRange, Color.green);

        if(Physics.SphereCast(controller.m_MettleEye.position, controller.enemyStats.lookSphereCastRadius,
        controller.m_MettleEye.forward, out hit, controller.enemyStats.lookRange) && hit.collider.CompareTag("MettlePrime")){

            controller.m_EnemyTarget = hit.transform;
            return true;  
            
        }else{

            return false;
        }

    }
}
